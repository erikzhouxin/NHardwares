using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R2000顺序操作
    /// </summary>
    public interface IR2000Queue
    {
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
        /// 是否连接
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        bool Disconnect();
        /// <summary>
        /// 使用当前配置重新连接
        /// </summary>
        /// <returns></returns>
        bool Reconnect(out string exception);
        /// <summary>
        /// 关闭当前RFID
        /// </summary>
        void Close();
        /// <summary>
        /// 获取频率
        /// <see cref="ReadCmdType.GetFrequencyRegion"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="model"></param>
        ReadAlertModel<T> GetFrequencyRegion<T>(byte readId, ref T model) where T : R2000Interfaces.GetFrequencyRegion;
        /// <summary>
        /// 盘存结余
        /// <see cref="ReadCmdType.InventoryReal"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="round"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> InventoryReal<T>(byte readId, byte round, ref T model) where T : R2000Interfaces.InventoryReal;
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="ReadCmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ReadAlertModel<T> FastSwitchInventory<T>(byte readId, byte[] antTimes, ref T model) where T : R2000Interfaces.FastSwitchInventory;
        /// <summary>
        /// 快速四天线盘存
        /// new { 0, 1, 1, 1, 2, 1, 3, 1, 0, 1 }四天线各轮询一次,延时0,次数1次
        /// <see cref="ReadCmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ReadAlertModel<T> FastSwitchInventory<T>(byte readId, ref T model) where T : R2000Interfaces.FastSwitchInventory;
        /// <summary>
        /// 设置工作天线
        /// <see cref="ReadCmdType.SetWorkAntenna"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ReadAlertModel<T> SetWorkAntenna<T>(byte readId, ReadAntennaType antType, ref T model) where T : R2000Interfaces.SetWorkAntenna;
        /// <summary>
        /// 设置选中标签
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="mode"></param>
        /// <param name="epc"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> SetAccessEpcMatch<T>(byte readId, byte mode, byte[] epc, ref T model) where T : R2000Interfaces.SetAccessEpcMatch;
        /// <summary>
        /// 读取选定标签EPC
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> ReadTagEpc<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag;
        /// <summary>
        /// 读取选定标签TID
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> ReadTagTid<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag;
        /// <summary>
        /// 读取选定标签TID
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<R600TagInfo> ReadTagTid(byte readId, byte start, byte length, ref R600TagInfo model);
        /// <summary>
        /// 读取选定标签User
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> ReadTagUser<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag;
        /// <summary>
        /// 读取选定标签User
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<R600TagInfo> ReadTagUser(byte readId, byte start, byte length, ref R600TagInfo model);
        /// <summary>
        /// 读取选定标签
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<R600TagInfo> ReadTag(byte readId, ReadAreaType area, byte start, byte length, ref R600TagInfo model);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="pass">长度为4</param>
        /// <param name="area"></param>
        /// <param name="start">epc从2开始</param>
        /// <param name="length"></param>
        /// <param name="newData"></param>
        /// <param name="oldKey"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        ReadAlertModel<T> WriteTag<T>(byte readId, byte[] pass, ReadAreaType area, byte start, byte length, byte[] newData, string oldKey, ref T model) where T : R2000Interfaces.WriteTag;
    }
    /// <summary>
    /// R2000顺序操作
    /// </summary>
    internal class R2000Queue : IR2000Queue
    {
        ITalkQueueModel _talker = new TalkQueueModel();
        /// <summary>
        /// 私有构造
        /// </summary>
        internal R2000Queue() { }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool Connect(string portName, int baudRate, out string exception)
        {
            _talker.Dispose();
            _talker = new SerialTalkQueueModel();
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
            _talker = new TcpTalkQueueModel();
            return _talker.Connect(ip, port, out exception);
        }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnected { get => _talker.IsConnected; }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public virtual bool Disconnect()
        {
            return _talker.Disconnect();
        }
        /// <summary>
        /// 重连
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Reconnect(out string msg)
        {
            return _talker.Connect(out msg);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public virtual void Close()
        {
            _talker.Dispose();
        }
        #region // 读数据
        /// <summary>
        /// 获取频率
        /// <see cref="ReadCmdType.GetFrequencyRegion"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="model"></param>
        public ReadAlertModel<T> GetFrequencyRegion<T>(byte readId, ref T model) where T : R2000Interfaces.GetFrequencyRegion
        {
            byte[] data = ReaderCaller.GetSendData(readId, ReadCmdType.GetFrequencyRegion);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 3)
                {
                    var freq = (ReadFreqRegionType)msgTran.AryData[0];
                    var start = (int)msgTran.AryData[1];
                    var interval = msgTran.AryData[2];
                    byte chanelQulity = 0x00;
                    model.ReadId = msgTran.ReadId;
                    model.FreqType = freq;
                    model.FreqValue = ReaderCaller.GetFreq(freq, start, interval, chanelQulity);
                    return new ReadAlertModel<T>(ReadCmdType.GetFrequencyRegion, model);
                }
                else if (msgTran.AryData.Length == 6)
                {
                    var freq = (ReadFreqRegionType)msgTran.AryData[0];
                    var start = new byte[] { msgTran.AryData[3], msgTran.AryData[4], msgTran.AryData[5] }.ConvertInt32();
                    var interval = msgTran.AryData[1];
                    byte chanelQulity = msgTran.AryData[2];
                    model.ReadId = msgTran.ReadId;
                    model.FreqType = freq;
                    model.FreqValue = ReaderCaller.GetFreq(freq, start, interval, chanelQulity);
                    return new ReadAlertModel<T>(ReadCmdType.GetFrequencyRegion, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                return GetAlertError(ReadCmdType.GetFrequencyRegion, code, $"取得射频规范失败，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.GetFrequencyRegion, exception, model);
        }
        /// <summary>
        /// 盘存结余
        /// <see cref="ReadCmdType.InventoryReal"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="round"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> InventoryReal<T>(byte readId, byte round, ref T model) where T : R2000Interfaces.InventoryReal
        {
            byte[] data = ReaderCaller.GetSendData(readId, ReadCmdType.InventoryReal, new byte[1] { round });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTrans = R600Message.Analysis(received);
                var message = string.Empty;
                if (msgTrans.Length > 0)
                {
                    foreach (var msgTran in msgTrans)
                    {
                        model.Current = msgTran;
                        model.ReadId = msgTran.ReadId;
                        if (msgTran.AryData.Length > 1)
                        {
                            if (msgTran.AryData.Length == 7)
                            {
                                var readRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                                var readCount = msgTran.AryData[3] * 256 * 256 * 256 + msgTran.AryData[4] * 256 * 256 + msgTran.AryData[5] * 256 + msgTran.AryData[6];
                                model.CurrentReadRate = readRate;
                                model.CurrentReadCount = readCount;
                                continue;
                            }
                            var tag = new R600TagInfo(R600TagInfo.InitType.Real, msgTran.AryData);
                            model.TryAddRealTag(tag);
                        }
                    }
                    return new ReadAlertModel<T>(ReadCmdType.InventoryReal, model);
                }
                return GetAlertError(ReadCmdType.InventoryReal, 0, $"盘存失败，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.InventoryReal, exception, model);
        }
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="ReadCmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ReadAlertModel<T> FastSwitchInventory<T>(byte readId, byte[] antTimes, ref T model) where T : R2000Interfaces.FastSwitchInventory
        {
            byte[] data = ReaderCaller.GetSendData(readId, ReadCmdType.FastSwitchInventory, antTimes);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTrans = R600Message.Analysis(received);
                var message = string.Empty;
                if (msgTrans.Length > 0)
                {
                    foreach (var msgTran in msgTrans)
                    {
                        model.Current = msgTran;
                        model.ReadId = msgTran.ReadId;
                        if (msgTran.AryData.Length > 2)
                        {
                            if (msgTran.AryData.Length == 7)
                            {
                                var readRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                                var readCount = msgTran.AryData[3] * 256 * 256 * 256 + msgTran.AryData[4] * 256 * 256 + msgTran.AryData[5] * 256 + msgTran.AryData[6];
                                model.CurrentReadRate = readRate;
                                model.CurrentReadCount = readCount;
                                continue;
                            }
                            var tag = new R600TagInfo(R600TagInfo.InitType.Fast, msgTran.AryData);
                            model.TryAddFastTag(tag);
                        }
                    }
                    return new ReadAlertModel<T>(ReadCmdType.FastSwitchInventory, model);
                }
                return GetAlertError(ReadCmdType.FastSwitchInventory, 0, $"快速四天线盘存，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.FastSwitchInventory, exception, model);
        }
        /// <summary>
        /// 快速四天线盘存
        /// new { 0, 1, 1, 1, 2, 1, 3, 1, 0, 1 }四天线各轮询一次,延时0,次数1次
        /// <see cref="ReadCmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ReadAlertModel<T> FastSwitchInventory<T>(byte readId, ref T model) where T : R2000Interfaces.FastSwitchInventory
            => FastSwitchInventory<T>(readId, new byte[10] { 0, 1, 1, 1, 2, 1, 3, 1, 0, 1 }, ref model);
        /// <summary>
        /// 设置工作天线
        /// <see cref="ReadCmdType.SetWorkAntenna"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ReadAlertModel<T> SetWorkAntenna<T>(byte readId, ReadAntennaType antType, ref T model) where T : R2000Interfaces.SetWorkAntenna
        {
            var data = ReaderCaller.GetSendData(readId, ReadCmdType.SetWorkAntenna, new byte[1] { (byte)antType });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
                {
                    model.ReadId = msgTran.ReadId;
                    model.CurrentAnt = antType;
                    return new ReadAlertModel<T>(ReadCmdType.SetWorkAntenna, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                model.CurrentAnt = ReadAntennaType.L1;
                return GetAlertError<T>(ReadCmdType.SetWorkAntenna, code, $"设置工作天线失败，失败原因：{message}", model);
            }
            model.CurrentAnt = ReadAntennaType.L1;
            return GetAlert404(ReadCmdType.SetWorkAntenna, exception, model);
        }
        /// <summary>
        /// 设置选中标签
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="mode"></param>
        /// <param name="epc"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> SetAccessEpcMatch<T>(byte readId, byte mode, byte[] epc, ref T model) where T : R2000Interfaces.SetAccessEpcMatch
        {
            byte[] btAryData = new byte[epc.Length + 2];
            btAryData[0] = mode;
            btAryData[1] = (byte)epc.Length;
            epc.CopyTo(btAryData, 2);
            var data = ReaderCaller.GetSendData(readId, ReadCmdType.SetAccessEpcMatch, btAryData);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
                {
                    model.ReadId = msgTran.ReadId;
                    model.CurrentEpc = epc;
                    return new ReadAlertModel<T>(ReadCmdType.SetAccessEpcMatch, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                model.CurrentEpc = new byte[] { };
                return GetAlertError<T>(ReadCmdType.SetAccessEpcMatch, code, $"选定标签失败，失败原因：{message}", model);
            }
            model.CurrentEpc = new byte[] { };
            return GetAlert404(ReadCmdType.SetAccessEpcMatch, exception, model);
        }
        /// <summary>
        /// 读取选定标签EPC
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> ReadTagEpc<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
            => ReadTag<T>(readId, ReadAreaType.EPC, start, length, ref model);
        /// <summary>
        /// 读取选定标签TID
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> ReadTagTid<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
            => ReadTag<T>(readId, ReadAreaType.TID, start, length, ref model);
        /// <summary>
        /// 读取选定标签TID
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<R600TagInfo> ReadTagTid(byte readId, byte start, byte length, ref R600TagInfo model)
            => ReadTag(readId, ReadAreaType.TID, start, length, ref model);
        /// <summary>
        /// 读取选定标签User
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> ReadTagUser<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
            => ReadTag<T>(readId, ReadAreaType.User, start, length, ref model);
        /// <summary>
        /// 读取选定标签User
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<R600TagInfo> ReadTagUser(byte readId, byte start, byte length, ref R600TagInfo model)
            => ReadTag(readId, ReadAreaType.User, start, length, ref model);
        /// <summary>
        /// 读取选定标签
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> ReadTag<T>(byte readId, ReadAreaType area, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
        {
            byte[] data = ReaderCaller.GetSendData(readId, ReadCmdType.ReadTag, new byte[3] { (byte)area, start, length });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length > 1)
                {
                    model.ReadId = readId;
                    if (msgTran.AryData.Length > 7)
                    {
                        var tag = new R600TagInfo(R600TagInfo.InitType.Read, msgTran.AryData);
                        switch (area)
                        {
                            case ReadAreaType.Reserved:
                                tag.Reserved = tag.Data;
                                break;
                            case ReadAreaType.TID:
                                tag.Tid = tag.Data;
                                break;
                            case ReadAreaType.User:
                                tag.User = tag.Data;
                                break;
                            case ReadAreaType.EPC:
                            default:
                                break;
                        }
                        model.TryAddReadTag(tag);
                    }
                    return new ReadAlertModel<T>(ReadCmdType.ReadTag, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                return GetAlertError<T>(ReadCmdType.ReadTag, code, $"读标签失败，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.ReadTag, exception, model);
        }

        /// <summary>
        /// 读取选定标签
        /// <see cref="ReadCmdType.ReadTag"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<R600TagInfo> ReadTag(byte readId, ReadAreaType area, byte start, byte length, ref R600TagInfo model)
        {
            byte[] data = ReaderCaller.GetSendData(readId, ReadCmdType.ReadTag, new byte[3] { (byte)area, start, length });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                if (msgTran.AryData.Length > 1)
                {
                    var tag = new R600TagInfo(R600TagInfo.InitType.Read, msgTran.AryData);
                    switch (area)
                    {
                        case ReadAreaType.Reserved:
                            tag.Reserved = tag.Data;
                            break;
                        case ReadAreaType.TID:
                            tag.Tid = tag.Data;
                            break;
                        case ReadAreaType.User:
                            tag.User = tag.Data;
                            break;
                        case ReadAreaType.EPC:
                        default:
                            break;
                    }
                    model.CombiReadTag(tag);
                    return new ReadAlertModel<R600TagInfo>(ReadCmdType.ReadTag, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                return GetAlertError<R600TagInfo>(ReadCmdType.ReadTag, code, $"读标签失败，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.ReadTag, exception, model);
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="pass">长度为4</param>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="newData"></param>
        /// <param name="oldKey"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReadAlertModel<T> WriteTag<T>(byte readId, byte[] pass, ReadAreaType area, byte start, byte length, byte[] newData, string oldKey, ref T model) where T : R2000Interfaces.WriteTag
        {
            byte[] btAryBuffer = new byte[newData.Length + 11];
            pass.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = (byte)area;
            btAryBuffer[5] = start;
            btAryBuffer[6] = (byte)(length + 2);
            newData.CopyTo(btAryBuffer, 11);
            var data = ReaderCaller.GetSendData(readId, ReadCmdType.WriteTag, btAryBuffer);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                if (msgTran.AryData.Length > 3 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
                {
                    var tag = new R600TagInfo(R600TagInfo.InitType.Write, msgTran.AryData);
                    model.TryAddWriteTag(tag, oldKey);
                    return new ReadAlertModel<T>(ReadCmdType.WriteTag, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : (msgTran.AryData.Length > 3 ? ReaderCaller.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : "未知错误");
                return GetAlertError<T>(ReadCmdType.ReadTag, code, $"写标签失败，失败原因：{message}", model);
            }
            return GetAlert404(ReadCmdType.ReadTag, exception, model);
        }
        private ReadAlertModel<T> GetAlertError<T>(ReadCmdType cmd, int code, string message, T model)
        {
            return new ReadAlertModel<T>(cmd, code, message, nameof(R2000Queue), cmd.ToEnumName(), model);
        }
        private ReadAlertModel<T> GetAlert404<T>(ReadCmdType cmd, Exception exception, T model)
        {
            return new ReadAlertModel<T>(cmd, 404, $"发送或读取内容失败，原因是{exception.Message}", nameof(R2000Queue), cmd.ToEnumName(), model);
        }
        #endregion
    }
}
