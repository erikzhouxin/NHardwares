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
    public class R2000Queue
    {
        ITalkModel _talker;
        /// <summary>
        /// 构造
        /// </summary>
        public R2000Queue()
        {
            _talker = new TalkModel();
        }

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
            _talker = new SerialTalkModel();
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
            _talker = new TcpTalkModel();
            return _talker.Connect(ip, port, out exception);
        }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnected { get => _talker.IsConnected; }
        #region // 读数据
        /// <summary>
        /// 获取频率
        /// <see cref="R600CmdType.GetFrequencyRegion"/>
        /// </summary>
        /// <param name="readId"></param>
        /// <param name="model"></param>
        public R600AlertModel<T> GetFrequencyRegion<T>(byte readId, ref T model) where T : R2000Interfaces.GetFrequencyRegion
        {
            byte[] data = R600Builder.GetSendData(readId, R600CmdType.GetFrequencyRegion);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 3)
                {
                    var freq = (R600FreqRegionType)msgTran.AryData[0];
                    var start = (int)msgTran.AryData[1];
                    var interval = msgTran.AryData[2];
                    byte chanelQulity = 0x00;
                    model.ReadId = msgTran.ReadId;
                    model.FreqType = freq;
                    model.FreqValue = R600Builder.GetFreq(freq, start, interval, chanelQulity);
                    return new R600AlertModel<T>(R600CmdType.GetFrequencyRegion, model);
                }
                else if (msgTran.AryData.Length == 6)
                {
                    var freq = (R600FreqRegionType)msgTran.AryData[0];
                    var start = new byte[] { msgTran.AryData[3], msgTran.AryData[4], msgTran.AryData[5] }.ConvertInt32();
                    var interval = msgTran.AryData[1];
                    byte chanelQulity = msgTran.AryData[2];
                    model.ReadId = msgTran.ReadId;
                    model.FreqType = freq;
                    model.FreqValue = R600Builder.GetFreq(freq, start, interval, chanelQulity);
                    return new R600AlertModel<T>(R600CmdType.GetFrequencyRegion, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                return GetAlertError(R600CmdType.GetFrequencyRegion, code, $"取得射频规范失败，失败原因：{message}", model);
            }
            return GetAlert404(R600CmdType.GetFrequencyRegion, exception, model);
        }

        /// <summary>
        /// 盘存结余
        /// <see cref="R600CmdType.InventoryReal"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="round"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public R600AlertModel<T> InventoryReal<T>(byte readId, byte round, ref T model) where T : R2000Interfaces.InventoryReal
        {
            byte[] data = R600Builder.GetSendData(readId, R600CmdType.InventoryReal, new byte[1] { round });
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
                            model.TryAddTag(tag);
                        }
                    }
                    return new R600AlertModel<T>(R600CmdType.InventoryReal, model);
                }
                return GetAlertError(R600CmdType.InventoryReal, 0, $"盘存失败，失败原因：{message}", model);
            }
            return GetAlert404(R600CmdType.InventoryReal, exception, model);
        }
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="R600CmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public R600AlertModel<T> FastSwitchInventory<T>(byte readId, byte[] antTimes, ref T model) where T : R2000Interfaces.FastSwitchInventory
        {
            byte[] data = R600Builder.GetSendData(readId, R600CmdType.FastSwitchInventory, antTimes);
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
                            model.TryAddTag(tag);
                        }
                    }
                    return new R600AlertModel<T>(R600CmdType.FastSwitchInventory, model);
                }
                return GetAlertError(R600CmdType.FastSwitchInventory, 0, $"快速四天线盘存，失败原因：{message}", model);
            }
            return GetAlert404(R600CmdType.FastSwitchInventory, exception, model);
        }
        /// <summary>
        /// 快速四天线盘存
        /// <see cref="R600CmdType.FastSwitchInventory"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public R600AlertModel<T> FastSwitchInventory<T>(byte readId, ref T model) where T : R2000Interfaces.FastSwitchInventory
        {
            return FastSwitchInventory<T>(readId, new byte[10] { 0, 1, 1, 1, 2, 1, 3, 1, 0, 1 }, ref model);
        }
        /// <summary>
        /// 设置工作天线
        /// <see cref="R600CmdType.SetWorkAntenna"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public R600AlertModel<T> SetWorkAntenna<T>(byte readId, R600AntennaType antType, ref T model) where T : R2000Interfaces.SetWorkAntenna
        {
            var data = R600Builder.GetSendData(readId, R600CmdType.SetWorkAntenna, new byte[1] { (byte)antType });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
                {
                    model.ReadId = msgTran.ReadId;
                    model.CurrentAnt = antType;
                    return new R600AlertModel<T>(R600CmdType.SetWorkAntenna, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                model.CurrentAnt = R600AntennaType.L1;
                return GetAlertError<T>(R600CmdType.SetWorkAntenna, code, $"设置工作天线失败，失败原因：{message}", model);
            }
            model.CurrentAnt = R600AntennaType.L1;
            return GetAlert404(R600CmdType.SetWorkAntenna, exception, model);
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
        public R600AlertModel<T> SetAccessEpcMatch<T>(byte readId, byte mode, byte[] epc, ref T model) where T : R2000Interfaces.SetAccessEpcMatch
        {
            byte[] btAryData = new byte[epc.Length + 2];
            btAryData[0] = mode;
            btAryData[1] = (byte)epc.Length;
            epc.CopyTo(btAryData, 2);
            var data = R600Builder.GetSendData(readId, R600CmdType.SetAccessEpcMatch, btAryData);
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
                {
                    model.ReadId = msgTran.ReadId;
                    model.CurrentEpc = epc;
                    return new R600AlertModel<T>(R600CmdType.SetAccessEpcMatch, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                model.CurrentEpc = new byte[] { };
                return GetAlertError<T>(R600CmdType.SetAccessEpcMatch, code, $"选定标签失败，失败原因：{message}", model);
            }
            model.CurrentEpc = new byte[] { };
            return GetAlert404(R600CmdType.SetAccessEpcMatch, exception, model);
        }
        /// <summary>
        /// 读取选定标签EPC
        /// <see cref="R600CmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public R600AlertModel<T> ReadTagEpc<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
        {
            return ReadTag<T>(readId, R600AreaType.EPC, start, length, ref model);
        }
        /// <summary>
        /// 读取选定标签TID
        /// <see cref="R600CmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public R600AlertModel<T> ReadTagTid<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
        {
            return ReadTag<T>(readId, R600AreaType.TID, start, length, ref model);
        }
        /// <summary>
        /// 读取选定标签User
        /// <see cref="R600CmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public R600AlertModel<T> ReadTagUser<T>(byte readId, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
        {
            return ReadTag<T>(readId, R600AreaType.User, start, length, ref model);
        }
        /// <summary>
        /// 读取选定标签
        /// <see cref="R600CmdType.ReadTag"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="readId"></param>
        /// <param name="area"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public R600AlertModel<T> ReadTag<T>(byte readId, R600AreaType area, byte start, byte length, ref T model) where T : R2000Interfaces.ReadTag
        {
            byte[] data = R600Builder.GetSendData(readId, R600CmdType.ReadTag, new byte[3] { (byte)area, start, length });
            if (_talker.Send(data, out byte[] received, out Exception exception))
            {
                var msgTran = new R600Message(received);
                model.Current = msgTran;
                if (msgTran.AryData.Length > 1)
                {
                    model.ReadId = readId;
                    var tag = new R600TagInfo(R600TagInfo.InitType.Read, msgTran.AryData);
                    switch (area)
                    {
                        case R600AreaType.Reserved:
                            tag.Reserved = tag.Data;
                            break;
                        case R600AreaType.TID:
                            tag.Tid = tag.Data;
                            break;
                        case R600AreaType.User:
                            tag.User = tag.Data;
                            break;
                        case R600AreaType.EPC:
                        default:
                            break;
                    }
                    model.TryAddReadTag(tag, area);
                    return new R600AlertModel<T>(R600CmdType.ReadTag, model);
                }
                int code = 0;
                string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
                return GetAlertError<T>(R600CmdType.ReadTag, code, $"读标签失败，失败原因：{message}", model);
            }
            return GetAlert404(R600CmdType.ReadTag, exception, model);
        }

        private R600AlertModel<T> GetAlertError<T>(R600CmdType cmd, int code, string message, T model)
        {
            return new R600AlertModel<T>(cmd, code, message, nameof(R2000Queue), cmd.ToString(), model);
        }
        private R600AlertModel<T> GetAlert404<T>(R600CmdType cmd, Exception exception, T model)
        {
            return new R600AlertModel<T>(cmd, 404, $"发送或读取内容失败，原因是{exception.Message}", nameof(R2000Queue), R600CmdType.GetFrequencyRegion.ToString(), model);
        }

        #endregion
        #region // 内部类
        /// <summary>
        /// 对话模型接口
        /// </summary>
        internal interface ITalkModel : IDisposable
        {
            /// <summary>
            /// 校验是否连接服务器
            /// </summary>
            /// <returns></returns>
            bool IsConnected { get; }
            /// <summary>
            /// 依据现有配置重新连接
            /// </summary>
            /// <returns></returns>
            bool Connect();
            /// <summary>
            /// 连接到服务端
            /// </summary>
            /// <param name="ip">IP地址</param>
            /// <param name="port">端口号</param>
            /// <param name="message">消息提示</param>
            /// <returns></returns>
            bool Connect(IPAddress ip, int port, out string message);
            /// <summary>
            /// 连接到服务端
            /// </summary>
            /// <param name="portName">串口号</param>
            /// <param name="bautRate">波特率</param>
            /// <param name="message">消息提示</param>
            /// <returns></returns>
            bool Connect(string portName, int bautRate, out string message);
            /// <summary>
            /// 断开连接
            /// </summary>
            /// <returns></returns>
            bool Disconnect();
            /// <summary>
            /// 发送数据包
            /// </summary>
            /// <param name="send"></param>
            /// <param name="received"></param>
            /// <param name="exception"></param>
            /// <returns></returns>
            bool Send(byte[] send, out byte[] received, out Exception exception);
        }
        /// <summary>
        /// 对话模型
        /// </summary>
        internal class TalkModel : ITalkModel
        {
            /// <summary>
            /// 轮询间隔(毫秒)
            /// 发送命令开始直至收到结果或者异常或者超过此时间
            /// </summary>
            public static int PollInterval { get; set; } = 500;
            /// <summary>
            /// 轮询次数(毫秒)
            /// 发送命令开始直至收到结果但收到的长度为0;
            /// </summary>
            public static int PollTimes { get; set; } = 5;
            /// <summary>
            /// 轮询等待时间
            /// 发送成功后等待时间
            /// </summary>
            public static int PollWaiter { get; set; } = 50;
            /// <summary>
            /// 缓存长度(默认4096)
            /// </summary>
            public static int PollLength { get; set; } = 4096;
            /// <summary>
            /// 锁定对象
            /// </summary>
            public static object LockObject { get; } = new object();
            /// <summary>
            /// 链接
            /// </summary>
            /// <param name="ip"></param>
            /// <param name="port"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public virtual bool Connect(IPAddress ip, int port, out string message)
            {
                message = "接口未实现";
                return false;
            }
            /// <summary>
            /// 链接
            /// </summary>
            /// <param name="portName"></param>
            /// <param name="bautRate"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public virtual bool Connect(string portName, int bautRate, out string message)
            {
                message = "接口未实现";
                return false;
            }
            /// <summary>
            /// 释放资源
            /// </summary>
            public virtual void Dispose()
            {

            }
            /// <summary>
            /// 已连接
            /// </summary>
            /// <returns></returns>
            public virtual bool IsConnected { get => false; }
            /// <summary>
            /// 断开连接
            /// </summary>
            /// <returns></returns>
            public virtual bool Disconnect()
            {
                return false;
            }
            /// <summary>
            /// 连接
            /// </summary>
            /// <returns></returns>
            public virtual bool Connect()
            {
                return false;
            }
            /// <summary>
            /// 发送
            /// </summary>
            /// <returns></returns>
            public virtual bool Send(byte[] send, out byte[] received, out Exception exception)
            {
                exception = new SocketException(400);
                received = null;
                return false;
            }
        }
        /// <summary>
        /// TCP连接模型
        /// </summary>
        internal class TcpTalkModel : TalkModel, ITalkModel
        {
            IPAddress _ip;
            int _port;
            TcpClient _client;
            Stream _stream;
            bool _isConnected;
            public TcpTalkModel()
            {
                _ip = IPAddress.Parse("192.168.0.178");
                _port = 4001;
            }
            /// <summary>
            /// 连接
            /// </summary>
            /// <param name="ipAddress"></param>
            /// <param name="port"></param>
            /// <param name="message"></param>
            /// <returns></returns>
            public override bool Connect(IPAddress ipAddress, int port, out string message)
            {
                message = string.Empty;
                try
                {
                    _client = new TcpClient();
                    _client.Connect(ipAddress, port);
                    _stream = _client.GetStream();    // 获取连接至远程的流

                    _isConnected = true;
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    _isConnected = false;
                    return false;
                }
            }
            /// <summary>
            /// 发送
            /// </summary>
            /// <param name="send"></param>
            /// <param name="received"></param>
            /// <param name="exception"></param>
            /// <returns></returns>
            public override bool Send(byte[] send, out byte[] received, out Exception exception)
            {
                // 获取锁定发送
                if (Monitor.TryEnter(LockObject, TimeSpan.FromMilliseconds(PollInterval)))
                {
                    try
                    {
                        if (!_isConnected || !IsConnected) // 未连接就退出
                        {
                            exception = new Exception("未连接或已经断开连接");
                            received = null;
                            Monitor.Exit(LockObject);
                            return false;
                        }
                        lock (_stream)
                        {
                            _stream.Write(send, 0, send.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                    Thread.Sleep(PollWaiter); // 发送成功后等100毫秒,确保已经开始接收,减少出错
                    try
                    {
                        var now = DateTime.Now;
                        byte[] buffer = new byte[PollLength];
                        byte[] result = new byte[PollLength];
                        var len = 0;
                        var times = PollTimes; // 确保数据完整的次数
                        while (true)
                        {
                            if ((DateTime.Now - now).TotalMilliseconds > PollInterval)
                            {
                                bool res;
                                if (len > 0)
                                {
                                    received = new byte[len];
                                    Array.Copy(result, received, len);
                                    res = true;
                                    exception = new Exception($"已超过轮询时间{PollInterval}毫秒，数据可能不完整");
                                }
                                else
                                {
                                    res = false;
                                    received = null;
                                    exception = new Exception($"已超过轮询时间{PollInterval}毫秒，未读取到数据");
                                }
                                Monitor.Exit(LockObject);
                                return res;
                            }
                            try
                            {
                                int readLen = _stream.Read(buffer, 0, buffer.Length);
                                if (readLen == 0)
                                {
                                    if (times-- > 0)
                                    {
                                        Thread.Sleep(10);
                                        continue;
                                    }
                                    else
                                    {
                                        if (len > 0) // 即使不完整也该返回此内容
                                        {
                                            exception = new Exception($"已超过轮询{PollTimes}次，数据可能不完整");
                                            received = new byte[len];
                                            Array.Copy(result, received, len);
                                            Monitor.Exit(LockObject);
                                            return true;
                                        }
                                        else
                                        {
                                            exception = new Exception($"已超过轮询{PollTimes}次，未获得数据");
                                            received = null;
                                            Monitor.Exit(LockObject);
                                            return false;
                                        }
                                    }
                                }
                                Array.Copy(buffer, 0, result, len, readLen);
                                len += readLen;
                                times = PollTimes;
                            }
                            catch { }
                            Thread.Sleep(10);//防止太快导致始终读取不全
                        }
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
                else
                {
                    exception = new TimeoutException($"已超过轮询时间{PollInterval}毫秒未获取到资源");
                    received = null;
                    return false;
                }
            }
            /// <summary>
            /// 是连接
            /// </summary>
            /// <returns></returns>
            public override bool IsConnected { get => _isConnected && (_client == null ? false : _client.Connected); }
            /// <summary>
            /// 断开连接
            /// </summary>
            /// <returns></returns>
            public override bool Disconnect()
            {
                return true;
            }
            /// <summary>
            /// 重新连接
            /// </summary>
            /// <returns></returns>
            public override bool Connect()
            {
                try
                {
                    _client.Connect(_ip, _port);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 释放
            /// </summary>
            public override void Dispose()
            {
                base.Dispose();
                _client?.Close();
            }
        }
        /// <summary>
        /// 串口连接模型
        /// </summary>
        internal class SerialTalkModel : TalkModel, ITalkModel
        {
            SerialPort serialPort;
            public SerialTalkModel()
            {
                serialPort = new SerialPort();
            }

            public override bool Connect(string portName, int bautRate, out string message)
            {
                try
                {
                    message = string.Empty;
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    serialPort.PortName = portName;
                    serialPort.BaudRate = bautRate;
                    serialPort.ReadTimeout = PollInterval;
                    serialPort.Open();
                }
                catch (UnauthorizedAccessException)
                {
                    message = $"对{portName}端口的访问被拒绝";
                    return false;
                }
                catch (InvalidOperationException)
                {
                    message = $"无法访问{portName}端口";
                    return false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    message = "串口定义参数不正确";
                    return false;
                }
                catch (ArgumentException)
                {
                    message = $"端口名称{portName}不正确或不支持此类型";
                    return false;
                }
                catch (IOException)
                {
                    message = $"端口{portName}已经打开";
                    return false;
                }
                catch (System.Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
                return true;
            }
            /// <summary>
            /// 已打开
            /// </summary>
            public override bool IsConnected { get => serialPort.IsOpen; }

            public override bool Send(byte[] aryBuffer, out byte[] received, out Exception exception)
            {
                // 获取锁定发送
                if (Monitor.TryEnter(LockObject, TimeSpan.FromMilliseconds(PollInterval)))
                {
                    if (serialPort == null || !serialPort.IsOpen)
                    {
                        received = null;
                        exception = new Exception("串口通信未初始化或未打开串口");
                        Monitor.Exit(LockObject);
                        return false;
                    }
                    try
                    {
                        serialPort.ReadTimeout = PollInterval;
                        serialPort.Write(aryBuffer, 0, aryBuffer.Length);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                    Thread.Sleep(PollWaiter); // 发送成功后等100毫秒,确保已经开始接收,减少出错
                    var len = 0;
                    var result = new byte[PollLength];
                    var now = DateTime.Now;
                    var times = PollTimes;
                    try
                    {
                        while (true)
                        {
                            if ((DateTime.Now - now).TotalMilliseconds > PollInterval)
                            {
                                bool res;
                                if (len > 0)
                                {
                                    received = new byte[len];
                                    Array.Copy(result, received, len);
                                    res = true;
                                    exception = new Exception($"已超过轮询时间{PollInterval}毫秒，数据可能不完整");
                                }
                                else
                                {
                                    res = false;
                                    received = null;
                                    exception = new Exception($"已超过轮询时间{PollInterval}毫秒，未读取到数据");
                                }
                                Monitor.Exit(LockObject);
                                return res;
                            }
                            int nCount = serialPort.BytesToRead;
                            if (nCount == 0)
                            {
                                if (times-- > 0)
                                {
                                    Thread.Sleep(10);
                                    continue;
                                }
                                else
                                {
                                    if (len > 0) // 即使不完整也该返回此内容
                                    {
                                        exception = new Exception($"已超过轮询{PollTimes}次，数据可能不完整");
                                        received = new byte[len];
                                        Array.Copy(result, received, len);
                                        Monitor.Exit(LockObject);
                                        return true;
                                    }
                                    else
                                    {
                                        exception = new Exception($"已超过轮询{PollTimes}次，未获得数据");
                                        received = null;
                                        Monitor.Exit(LockObject);
                                        return false;
                                    }
                                }
                            }
                            times = PollTimes;
                            serialPort.Read(result, len, nCount);
                            len += nCount;
                            Thread.Sleep(10);
                        }
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        if (len > 0)
                        {
                            received = new byte[len];
                            Array.Copy(result, received, len);
                        }
                        else
                        {
                            received = null;
                        }
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
                else
                {
                    exception = new TimeoutException($"已超过轮询时间{PollInterval}毫秒未获取到资源");
                    received = null;
                    return false;
                }
            }
            public override void Dispose()
            {
                base.Dispose();
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Dispose();
            }
        }
        #endregion
    }
}
