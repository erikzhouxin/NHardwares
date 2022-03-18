using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 阅读逻辑
    /// </summary>
    public interface IReadLogical : IDisposable
    {
        /// <summary>
        /// 是连接
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Connect(string portName, int baudRate, out string exception);
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Connect(IPAddress ip, int port, out string exception);
        /// <summary>
        /// 获取盘点内容包含TID
        /// </summary>
        /// <param name="readId">阅读器标识</param>
        /// <returns></returns>
        /// <see cref="ReadDescriptionModel.GetCmdInventory"/>
        /// <see cref="ReadDescriptionModel.GetCmdRead"/>
        IAlertLogical GetInventoryRealWithTid(int readId);
        /// <summary>
        /// 获取盘点内容包含TID
        /// </summary>
        /// <param name="readId">阅读器标识</param>
        /// <param name="repeat">次数</param>
        /// <returns></returns>
        /// <see cref="ReadDescriptionModel.GetCmdInventory"/>
        /// <see cref="ReadDescriptionModel.GetCmdRead"/>
        IAlertLogical GetInventoryRealWithTid(int readId, int repeat);
        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        bool Close();
    }
    internal class ReadLogical : IReadLogical
    {
        /// <summary>
        /// 内部链接模型
        /// </summary>
        private ILogicalTalkModel _talker;
        /// <summary>
        /// 连接模型
        /// </summary>
        public ReadLogical()
        {
            _talker = new LogicalTalkModel();
        }
        public bool IsConnected { get => _talker.IsConnected; }

        public bool Connect(string portName, int baudRate, out string exception)
        {
            _talker.Dispose();
            _talker = new SerialPortLogicalTalkModel();
            return _talker.Connect(portName, baudRate, out exception);
        }

        public bool Connect(IPAddress ip, int port, out string exception)
        {
            _talker.Dispose();
            _talker = new TcpIpLogicalTalkModel();
            return _talker.Connect(ip, port, out exception);
        }
        public IAlertLogical GetInventoryRealWithTid(int readId) => GetInventoryRealWithTid(readId, 0xFF);
        public IAlertLogical GetInventoryRealWithTid(int readId, int repeat)
        {
            var sendBytes = ReaderCaller.GetSendData(readId, ReadCmdType.InventoryReal, new byte[] { (byte)repeat });
            var result = new AlertLogical(true, "");
            if (_talker.Send(sendBytes, (tagArr) =>
            {
                if (tagArr.Length == 6) { return true; } // 错误
                if (tagArr.Length == 12) { return true; } // 完成
                var tag = AlertTagInfo.GetInventoryReal(tagArr);
                if (!tag.IsValid) { return false; }
                result.AddTags(tag);
                return false;
            }, out Exception ex))
            {
                foreach (var tag in result.Tags)
                {
                    SetAccessEpcMatch(tag.Address, tag.EPC);// 选中标签f
                    SetAccessEpcMatch(tag.Address, tag.EPC);// 选中标签f
                    // 读取TID
                    var readRes = GetAccessTagTid(tag.Address);
                    if (readRes.IsSuccess && readRes.Tags.Length == 1) 
                    {
                        var tagInfo = tag as AlertTagInfo;
                        var tagModel = readRes.Tags[0] as AlertTagInfo;
                        tagInfo.TID = tagModel.TID;
                        tagInfo.TIDHex = tagModel.TIDHex;
                        tagInfo.CRC = tagModel.CRC;
                    }
                }
                return result;
            }
            return new AlertLogical(false, ex);
        }
        public IAlertLogical GetAccessTagTid(int readId)
        {
            var sendBytes = ReaderCaller.GetSendData(readId, ReadCmdType.ReadTag, new byte[] { (byte)ReadAreaType.TID, (byte)0, (byte)6 });
            var res = new AlertLogical(true, "");
            if (_talker.Send(sendBytes, (arr) =>
            {
                if (arr.Length == 6)
                {
                    res.IsSuccess = false;
                    res.Message = ReaderCaller.FormatErrorCode(arr[arr.Length - 2]);
                    return true;
                }
                var model = AlertTagInfo.GetInventoryTid(arr);
                if (model.IsValid)
                {
                    res.AddTags(model);
                }
                return true;
            }, out Exception ex))
            {
                return res;
            }
            return new AlertLogical(false, ex);
        }
        public IAlertLogical GetAccessTagArea(int readId, ReadAreaType area, int start, int epcLen, byte[] pass)
        {
            var sendBytes = ReaderCaller.GetSendData(readId, ReadCmdType.ReadTag, new byte[] { (byte)area, (byte)start, (byte)epcLen, pass[0], pass[1], pass[2], pass[3] });
            if (_talker.Send(sendBytes, (arr) =>
            {
                if (arr.Length == 6)
                {
                    var error = ReaderCaller.FormatErrorCode(arr[arr.Length - 2]);
                }
                return true;
            }, out Exception ex))
            {
                return new AlertLogical(false, ex);
            }
            return new AlertLogical(false, ex);

        }
        public IAlertLogical SetAccessEpcMatch(int readId, byte[] epc)
        {
            byte[] sData = new byte[] { 0x01 }; // 取消
            if (epc != null && epc.Length > 0)
            {
                sData = new byte[epc.Length + 2];
                sData[0] = 0x00; // 选中
                sData[1] = (byte)epc.Length;
                epc.CopyTo(sData, 2);
            }
            var sendBytes = ReaderCaller.GetSendData(readId, ReadCmdType.SetAccessEpcMatch, sData);
            if (_talker.Send(sendBytes, (arr) =>
            {
                if (arr.Length == 6)
                {
                    var error = ReaderCaller.FormatErrorCode(arr[arr.Length - 2]);
                }
                return true;
            }, out Exception ex))
            {
                return new AlertLogical(true, ex);
            }
            return new AlertLogical(false, ex);
        }

        public void Dispose()
        {
            _talker.Dispose();
        }
        public bool Close()
        {
            _talker.Dispose();
            return true;
        }
    }
    /// <summary>
    /// 提示逻辑
    /// </summary>
    public interface IAlertLogical
    {
        /// <summary>
        /// 是成功
        /// </summary>
        bool IsSuccess { get; }
        /// <summary>
        /// 消息提示
        /// </summary>
        String Message { get; }
        /// <summary>
        /// 标签列表
        /// </summary>
        IAlertTagInfo[] Tags { get; }
        /// <summary>
        /// 异常内容
        /// </summary>
        Exception Exception { get; }
    }
    /// <summary>
    /// 提示标签信息
    /// </summary>
    public interface IAlertTagInfo
    {
        /// <summary>
        /// 头=>0xA0
        /// </summary>
        byte Head { get; }
        /// <summary>
        /// 长度
        /// </summary>
        byte Len { get; }
        /// <summary>
        /// 地址
        /// </summary>
        byte Address { get; }
        /// <summary>
        /// 命令
        /// </summary>
        ReadCmdType Cmd { get; }
        /// <summary>
        /// 读取标签存储区域
        /// EPC/TID等
        /// </summary>
        ReadAreaType MemBank { get; }
        /// <summary>
        /// 读取数据首地址
        /// </summary>
        byte WordAdd { get; }
        /// <summary>
        /// 读取数据长度
        /// 两个字节为一个字长
        /// </summary>
        byte WordCnt { get; }
        /// <summary>
        /// 密码区4个字节
        /// new byte[4]
        /// </summary>
        byte[] PassWord { get; }
        /// <summary>
        /// 校验位
        /// </summary>
        byte Check { get; }
        /// <summary>
        /// 是合法数据
        /// </summary>
        bool IsValid { get; }
        /// <summary>
        /// 电子产品代码
        /// </summary>
        byte[] EPC { get; set; }
    }
    internal class AlertLogical : IAlertLogical
    {
        public AlertLogical(bool isSuccess, string exception)
        {
            IsSuccess = isSuccess;
            Message = exception;
        }
        public AlertLogical(bool isSuccess, Exception exception)
        {
            IsSuccess = isSuccess;
            Exception = exception;
            Message = exception.Message;
        }
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        public IAlertTagInfo Current { get; set; }
        public IAlertTagInfo[] Tags { get => _tags.ToArray(); }
        private List<IAlertTagInfo> _tags = new List<IAlertTagInfo>();
        public Exception Exception { get; set; }

        internal void AddTags(IAlertTagInfo tag)
        {
            _tags.Add(tag);
        }
    }
    internal class AlertTagInfo : IAlertTagInfo
    {
        /// <summary>
        /// 头=>0xA0
        /// </summary>
        public byte Head { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public byte Len { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public byte Address { get; set; }
        /// <summary>
        /// 命令
        /// </summary>
        public ReadCmdType Cmd { get; set; }
        /// <summary>
        /// 读取标签存储区域
        /// EPC/TID等
        /// </summary>
        public ReadAreaType MemBank { get; set; }
        /// <summary>
        /// 读取数据首地址
        /// </summary>
        public byte WordAdd { get; set; }
        /// <summary>
        /// 读取数据长度
        /// 两个字节为一个字长
        /// </summary>
        public byte WordCnt { get; set; }
        /// <summary>
        /// 密码区4个字节
        /// new byte[4]
        /// </summary>
        public byte[] PassWord { get; set; }
        /// <summary>
        /// 校验位
        /// </summary>
        public byte Check { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] CRC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] EPC { get; set; }
        /// <summary>
        /// EPC的16进制字符串
        /// </summary>
        public String EPCHex { get; set; }
        /// <summary>
        /// Tag标识串
        /// </summary>
        public byte[] TID { get; set; }
        /// <summary>
        /// TID的16进制字符串
        /// </summary>
        public String TIDHex { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 消息数据
        /// </summary>
        public byte[] AryData { get; set; }
        /// <summary>
        /// 是合法
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 天线
        /// </summary>
        public ReadAntennaType Ant { get; set; }
        /// <summary>
        /// 读取次数
        /// </summary>
        public byte ReadCount { get; set; }
        /// <summary>
        /// 标签的实时 RSSI
        /// </summary>
        public byte RSSI { get; set; }
        /// <summary>
        /// 读取标签的频点参数
        /// </summary>
        public byte Freq { get; set; }
        /// <summary>
        /// 实时盘点标签
        /// </summary>
        /// <param name="tagArr"></param>
        /// <returns></returns>
        public static IAlertTagInfo GetInventoryReal(byte[] tagArr)
        {
            var tagInfo = new AlertTagInfo();
            if (tagArr == null || tagArr.Length == 0) { return tagInfo; }
            tagInfo.Data = tagArr;
            tagInfo.Head = tagArr[0];
            byte btCK = ReaderCaller.CheckByte(tagArr, 0, tagArr.Length - 1);
            if (btCK != tagArr[tagArr.Length - 1])
            {
                return tagInfo;
            }
            tagInfo.Len = tagArr[1];
            tagInfo.Address = tagArr[2];
            tagInfo.Cmd = (ReadCmdType)tagArr[3];
            tagInfo.Check = btCK;
            if (tagArr.Length > 5)
            {
                tagInfo.AryData = new byte[tagArr.Length - 5];
                Array.Copy(tagArr, 4, tagInfo.AryData, 0, tagArr.Length - 5);
                if (tagInfo.AryData.Length > 5)
                {
                    tagInfo.IsValid = true;
                    int nEpcLength = tagInfo.AryData.Length - 4;
                    var epc = new byte[nEpcLength];
                    Array.Copy(tagInfo.AryData, 3, epc, 0, nEpcLength); // string strEPC = R600Method.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                    var pc = new byte[2];
                    Array.Copy(tagInfo.AryData, 1, pc, 0, 2); // string strPC = R600Method.ByteArrayToString(msgTran.AryData, 1, 2);
                    var rssi = tagInfo.AryData[tagInfo.AryData.Length - 1];
                    byte btTemp = tagInfo.AryData[0];
                    tagInfo.EPC = epc;
                    tagInfo.EPCHex = epc.GetHexString();
                    tagInfo.PC = pc;
                    tagInfo.Ant = (ReadAntennaType)(btTemp & 0x03);
                    tagInfo.RSSI = rssi;
                    tagInfo.Freq = (byte)(btTemp >> 2);
                }
            }
            return tagInfo;
        }
        /// <summary>
        /// 读取TID内容
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static IAlertTagInfo GetInventoryTid(byte[] arr)
        {
            var model = new AlertTagInfo();
            int nLen = arr.Length;
            byte btCK = ReaderCaller.CheckByte(arr, 0, arr.Length - 1);
            if (btCK != arr[nLen - 1])
            {
                model.IsValid = false;
                return model;
            }
            model.Head = arr[0];
            model.Len = arr[1];
            model.Address = arr[2];
            model.Cmd = (ReadCmdType)arr[3];
            model.Check = btCK;
            if (nLen > 5)
            {
                model.IsValid = true;
                model.AryData = new byte[arr.Length - 5];
                Array.Copy(arr, 4, model.AryData, 0, arr.Length - 5);
                if(model.AryData.Length > 7)
                {
                    nLen = model.AryData.Length;
                    int nDataLen = Convert.ToInt32(model.AryData[nLen - 3]);
                    int nEpcLen = Convert.ToInt32(model.AryData[2]) - nDataLen - 4;
                    byte[] pc = new byte[2];
                    Array.Copy(model.AryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                    byte[] epc = new byte[nEpcLen];
                    Array.Copy(model.AryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                    byte[] crc = new byte[2];
                    Array.Copy(model.AryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                    byte[] data = new byte[nDataLen];
                    Array.Copy(model.AryData, 7 + nEpcLen, data, 0, nDataLen);// string strData = R600Method.ByteArrayToString(aryData, 7 + nEpcLen, nDataLen);
                    byte byAntId = (byte)(model.AryData[nLen - 2] & 0x03);

                    model.EPC = epc;
                    model.EPCHex = epc.GetHexString();
                    model.PC = pc;
                    model.CRC = crc;
                    model.TID = data;
                    model.TIDHex = data.GetHexString();
                    model.Ant = (ReadAntennaType)byAntId;
                    model.ReadCount = model.AryData[nLen - 1];
                }
            }
            return model;
        }
    }
}
