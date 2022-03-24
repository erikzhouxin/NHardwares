using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 读写逻辑
    /// </summary>
    public class ReaderWriterLogical : IDisposable
    {
        private ITalkReadModel _talker;
        private Dictionary<string, AlertReadWritTag> _epcDic = new Dictionary<string, AlertReadWritTag>();
        private Dictionary<string, AlertReadWritTag> _tidDic = new Dictionary<string, AlertReadWritTag>();
        /// <summary>
        /// 实时盘点带着TID
        /// </summary>
        public event Action<AlertReadWritTag> InventoryRealWithTid;
        /// <summary>
        /// 写Epc标签
        /// </summary>
        public event Action<AlertReadWritTag> WriteEpcTag;
        /// <summary>
        /// 构造
        /// </summary>
        public ReaderWriterLogical()
        {
            _talker = new TalkReadModel();
        }
        /// <summary>
        /// 是连接
        /// </summary>
        public bool IsConnected { get => _talker.IsConnected; }
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool Connect(string portName, int baudRate, out string exception)
        {
            _talker.Dispose();
            _talker = new SerialLogicalTalkModel();
            _talker.Received += ReceiveDataCallback;
            _talker.SendError += ErrorDataCallback;
            return _talker.Connect(portName, baudRate, out exception);
        }
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool Connect(IPAddress ip, int port, out string exception)
        {
            _talker.Dispose();
            _talker = new TcpLogicalTalkModel();
            _talker.Received += ReceiveDataCallback;
            _talker.SendError += ErrorDataCallback;
            return _talker.Connect(ip, port, out exception);
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveDataCallback(byte[] aryData)
        {
            if (aryData.Length > 3)
            {
                switch ((ReadCmdType)aryData[3])
                {
                    case ReadCmdType.InventoryReal:
                        {
                            var tag = AlertReadWritTag.GetInventoryReal(aryData);
                            if (tag.IsError)
                            {
                                return;
                            }
                            if (tag.IsValid)
                            {
                                if (tag.IsEnd)
                                {
                                    foreach (var item in _epcDic.Values.ToArray())
                                    {
                                        if (_tidDic.Any(s => s.Value.EPCHex == item.EPCHex)) { continue; }
                                        SetAccessEpcMatch(item.Address, item.EPC); // 选中
                                        Thread.Sleep(20);
                                        ReadTagArea(item.Address, ReadAreaType.TID);
                                        Thread.Sleep(50);
                                    }
                                    return;
                                }
                                _epcDic[tag.EPCHex] = tag;
                                return;
                            }
                        }
                        break;
                    case ReadCmdType.ReadTag:
                        {
                            var tagA = AlertReadWritTag.GetInventoryTid(aryData);
                            if (tagA.IsError) { return; }
                            if (tagA.IsValid)
                            {
                                if (!_tidDic.ContainsKey(tagA.TIDHex))
                                {
                                    _tidDic[tagA.TIDHex] = tagA;
                                    var tagM = _epcDic.Values.FirstOrDefault(item => item.EPCHex == tagA.EPCHex && item.TID.Length == 0);
                                    if (tagM != null)
                                    {
                                        tagA.PC = tagM.PC;
                                    }
                                    InventoryRealWithTid?.Invoke(tagA);
                                }
                            }
                        }
                        break;
                    case ReadCmdType.WriteTag:
                        {
                            AlertReadWritTag tagB;
                            try
                            {
                                tagB = AlertReadWritTag.GetWriteTag(aryData);
                            }
                            catch (Exception ex)
                            {
                                tagB = AlertReadWritTag.GetWriteTagError(ex);
                            }
                            WriteEpcTag?.Invoke(tagB);
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private bool ReadTagArea(byte address, ReadAreaType areaType)
        {
            byte[] sendData;
            switch (areaType)
            {
                case ReadAreaType.TID:
                    {
                        sendData = ReaderCaller.GetSendData(address, ReadCmdType.ReadTag, new byte[3] { (byte)areaType, 0, 6 });
                    }
                    break;
                case ReadAreaType.Reserved:
                case ReadAreaType.EPC:
                case ReadAreaType.User:
                default:
                    return true;
            }
            return _talker.Send(sendData);
        }
        /// <summary>
        /// 取消选中
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool SetAccessEpcMatch(byte address)
        {
            var res = _talker.Send(ReaderCaller.GetSendData(address, ReadCmdType.SetAccessEpcMatch, new byte[] { 0x01 })); // 取消
            Thread.Sleep(25);
            return res;
        }
        /// <summary>
        /// 选中标签
        /// </summary>
        /// <param name="address"></param>
        /// <param name="epc"></param>
        /// <returns></returns>
        public bool SetAccessEpcMatch(byte address, byte[] epc)
        {
            int nLen = Convert.ToInt32(epc.Length) + 2;
            byte[] btAryData = new byte[nLen];
            btAryData[0] = 0x00;
            btAryData[1] = (byte)epc.Length;
            epc.CopyTo(btAryData, 2);
            var sendData = ReaderCaller.GetSendData(address, ReadCmdType.SetAccessEpcMatch, btAryData);
            var res = _talker.Send(sendData); // 选中
            Thread.Sleep(30);
            return res;
        }

        /// <summary>
        /// 错误回调
        /// </summary>
        private void ErrorDataCallback(byte[] aryData, Exception ex)
        {

        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _talker.Dispose();
        }
        /// <summary>
        /// 试试盘点
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="round"></param>
        public bool InventoryReal(byte readId, byte round)
        {
            var sendData = ReaderCaller.GetSendData(readId, ReadCmdType.InventoryReal, new byte[1] { round });
            return _talker.Send(sendData);
        }
        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="power"></param>
        public bool SetOutputPower(int readId, int power)
        {
            var sendData = ReaderCaller.GetSendData(readId, ReadCmdType.SetOutputPower, new byte[1] { (byte)power });
            return _talker.Send(sendData);
        }

        /// <summary>
        /// 清空字典
        /// </summary>
        public void ClearDic()
        {
            _epcDic.Clear();
            _tidDic.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="selectEpc"></param>
        /// <returns></returns>
        public bool WriteTagEpc(byte address, byte[] selectEpc)
        {
            byte[] aryData = new byte[selectEpc.Length + 9];
            aryData[4] = 1;
            aryData[5] = 1;
            aryData[6] = (byte)(selectEpc.Length / 2 + selectEpc.Length % 2 + 1);
            aryData[7] = 0x40;
            aryData[8] = 0x00;
            selectEpc.CopyTo(aryData, 9);
            var sendData = ReaderCaller.GetSendData(address, ReadCmdType.WriteTag, aryData);
            var res = _talker.Send(sendData);
            Thread.Sleep(50);
            return res;
        }
    }
    /// <summary>
    /// 提示读写
    /// </summary>
    public class AlertReaderWriter
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="exception"></param>
        public AlertReaderWriter(bool isSuccess, string exception)
        {
            IsSuccess = isSuccess;
            Message = exception;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="exception"></param>
        public AlertReaderWriter(bool isSuccess, Exception exception)
        {
            IsSuccess = isSuccess;
            Exception = exception;
            Message = exception.Message;
        }
        /// <summary>
        /// 是成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        public AlertReadWritTag Current { get; set; }
        /// <summary>
        /// 所有标签
        /// </summary>
        public AlertReadWritTag[] Tags { get => _tags.ToArray(); }
        private List<AlertReadWritTag> _tags = new List<AlertReadWritTag>();
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="tag"></param>
        internal void AddTags(AlertReadWritTag tag)
        {
            _tags.Add(tag);
        }
    }
    /// <summary>
    /// 提示读写标签
    /// </summary>
    public class AlertReadWritTag
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
        /// 是错误
        /// </summary>
        public bool IsError { get; set; }
        private byte _errorCode;
        /// <summary>
        /// 错误代码
        /// </summary>
        public byte ErrorCode
        {
            get => _errorCode;
            set
            {
                _errorCode = value;
                _errorMsg = ReaderCaller.FormatErrorCode(value);
            }
        }
        private string _errorMsg;
        /// <summary>
        /// 错误信息
        /// </summary>
        public String ErrorMessage { get => _errorMsg; set => _errorMsg = value; }
        /// <summary>
        /// 是结束
        /// </summary>
        public bool IsEnd { get; set; }
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
        /// 构造
        /// </summary>
        public AlertReadWritTag()
        {
            EPC = new byte[0];
            TID = new byte[0];
            EPCHex = String.Empty;
            TIDHex = String.Empty;
            AryData = new byte[0];
            Data = new byte[0];
            CRC = new byte[2];
            PC = new byte[2];
            PassWord = new byte[4];
            Head = 0xA0;
            Address = 1;
        }
        /// <summary>
        /// 实时盘点标签
        /// </summary>
        /// <param name="tagArr"></param>
        /// <returns></returns>
        public static AlertReadWritTag GetInventoryReal(byte[] tagArr)
        {
            var tagInfo = new AlertReadWritTag();
            if (tagArr == null || tagArr.Length == 0) { return tagInfo; }
            tagInfo.Data = tagArr;
            tagInfo.Head = tagArr[0];
            byte btCK = ReaderCaller.CheckByte(tagArr, 0, tagArr.Length - 1);
            if (btCK != tagArr[tagArr.Length - 1])
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = 0xFF;
                tagInfo.IsValid = false;
                return tagInfo;
            }
            tagInfo.Len = tagArr[1];
            tagInfo.Address = tagArr[2];
            tagInfo.Cmd = (ReadCmdType)tagArr[3];
            tagInfo.Check = btCK;
            if (tagArr.Length < 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = 0xFF;
                tagInfo.IsValid = false;
                return tagInfo;
            }
            if (tagArr.Length == 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = tagArr[4];
                tagInfo.AryData = new byte[] { tagInfo.ErrorCode };
                return tagInfo;
            }
            tagInfo.AryData = new byte[tagArr.Length - 5];
            Array.Copy(tagArr, 4, tagInfo.AryData, 0, tagArr.Length - 5);
            if (tagInfo.AryData.Length > 5)
            {
                tagInfo.IsValid = true;
                tagInfo.IsEnd = tagInfo.AryData.Length == 7;
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
            return tagInfo;
        }
        /// <summary>
        /// 读取TID内容
        /// </summary>
        /// <param name="tagArr"></param>
        /// <returns></returns>
        public static AlertReadWritTag GetInventoryTid(byte[] tagArr)
        {
            var tagInfo = new AlertReadWritTag();
            int nLen = tagArr.Length;
            byte btCK = ReaderCaller.CheckByte(tagArr, 0, tagArr.Length - 1);
            if (btCK != tagArr[nLen - 1])
            {
                tagInfo.IsValid = false;
                return tagInfo;
            }
            tagInfo.Head = tagArr[0];
            tagInfo.Len = tagArr[1];
            tagInfo.Address = tagArr[2];
            tagInfo.Cmd = (ReadCmdType)tagArr[3];
            tagInfo.Check = btCK;
            if (tagArr.Length < 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = 0xFF;
                tagInfo.IsValid = false;
                return tagInfo;
            }
            if (tagArr.Length == 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = tagArr[4];
                tagInfo.AryData = new byte[] { tagInfo.ErrorCode };
                return tagInfo;
            }
            tagInfo.AryData = new byte[tagArr.Length - 5];
            Array.Copy(tagArr, 4, tagInfo.AryData, 0, tagArr.Length - 5);
            if (tagInfo.AryData.Length > 7)
            {
                tagInfo.IsValid = true;
                nLen = tagInfo.AryData.Length;
                int nDataLen = Convert.ToInt32(tagInfo.AryData[nLen - 3]);
                int nEpcLen = Convert.ToInt32(tagInfo.AryData[2]) - nDataLen - 4;
                byte[] pc = new byte[2];
                Array.Copy(tagInfo.AryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                byte[] epc = new byte[nEpcLen];
                Array.Copy(tagInfo.AryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                byte[] crc = new byte[2];
                Array.Copy(tagInfo.AryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                byte[] data = new byte[nDataLen];
                Array.Copy(tagInfo.AryData, 7 + nEpcLen, data, 0, nDataLen);// string strData = R600Method.ByteArrayToString(aryData, 7 + nEpcLen, nDataLen);
                byte byAntId = (byte)(tagInfo.AryData[nLen - 2] & 0x03);

                tagInfo.EPC = epc;
                tagInfo.EPCHex = epc.GetHexString();
                tagInfo.PC = pc;
                tagInfo.CRC = crc;
                tagInfo.TID = data;
                tagInfo.TIDHex = data.GetHexString();
                tagInfo.Ant = (ReadAntennaType)byAntId;
                tagInfo.ReadCount = tagInfo.AryData[nLen - 1];
            }
            return tagInfo;
        }

        internal AlertReadWritTag Copy()
        {
            return new AlertReadWritTag
            {
                Address = Address,
                Ant = Ant,
                AryData = AryData,
                Check = Check,
                Cmd = Cmd,
                CRC = CRC,
                Data = Data,
                EPC = EPC,
                EPCHex = EPCHex,
                ErrorCode = ErrorCode,
                Freq = Freq,
                Head = Head,
                IsEnd = IsEnd,
                IsError = IsError,
                IsValid = IsValid,
                Len = Len,
                MemBank = MemBank,
                PassWord = PassWord,
                PC = PC,
                ReadCount = ReadCount,
                RSSI = RSSI,
                TID = TID,
                TIDHex = TIDHex,
                WordAdd = WordAdd,
                WordCnt = WordCnt,
            };
        }

        internal static AlertReadWritTag GetWriteTag(byte[] tagArr)
        {
            var tagInfo = new AlertReadWritTag();
            int nLen = tagArr.Length;
            byte btCK = ReaderCaller.CheckByte(tagArr, 0, tagArr.Length - 1);
            if (btCK != tagArr[nLen - 1])
            {
                tagInfo.IsValid = false;
                return tagInfo;
            }
            tagInfo.Head = tagArr[0];
            tagInfo.Len = tagArr[1];
            tagInfo.Address = tagArr[2];
            tagInfo.Cmd = (ReadCmdType)tagArr[3];
            tagInfo.Check = btCK;
            if (tagArr.Length == 1)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = tagArr[0];
                tagInfo.AryData = new byte[] { tagInfo.ErrorCode };
                return tagInfo;
            }
            if (tagArr.Length < 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = 0xFF;
                tagInfo.IsValid = false;
                return tagInfo;
            }
            if (tagArr.Length == 6)
            {
                tagInfo.IsError = true;
                tagInfo.ErrorCode = tagArr[4];
                tagInfo.AryData = new byte[] { tagInfo.ErrorCode };
                return tagInfo;
            }
            tagInfo.AryData = new byte[tagArr.Length - 5];
            Array.Copy(tagArr, 4, tagInfo.AryData, 0, tagArr.Length - 5);
            if (tagInfo.AryData.Length > 7)
            {
                tagInfo.IsValid = true;
                nLen = tagInfo.AryData.Length;
                int nEpcLen = tagInfo.AryData[2] - 4;
                byte[] pc = new byte[2];
                Array.Copy(tagInfo.AryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                byte[] epc = new byte[nEpcLen];
                Array.Copy(tagInfo.AryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                byte[] crc = new byte[2];
                Array.Copy(tagInfo.AryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);

                byte byAntId = (byte)(tagInfo.AryData[nLen - 2] & 0x03);

                tagInfo.EPC = epc;
                tagInfo.EPCHex = epc.GetHexString();
                tagInfo.PC = pc;
                tagInfo.CRC = crc;
                tagInfo.Ant = (ReadAntennaType)byAntId;
                tagInfo.ReadCount = tagInfo.AryData[nLen - 1];
            }
            return tagInfo;
        }
        internal static AlertReadWritTag GetWriteTagError(Exception ex)
        {
            var tagInfo = new AlertReadWritTag();
            tagInfo.IsError = true;
            tagInfo.ErrorMessage = ex.Message;
            return tagInfo;
        }
    }
}
