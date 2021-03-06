using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 通用模型接口
    /// </summary>
    internal interface ITalkModel
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
        bool Connect(out string exception);
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
    }
    /// <summary>
    /// 顺序式模型接口
    /// </summary>
    internal interface ITalkQueueModel : ITalkModel, IDisposable
    {
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
    /// 逻辑顺序式模型接口
    /// </summary>
    internal interface ILogicalTalkModel : ITalkModel, IDisposable
    {
        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="send"></param>
        /// <param name="Analysis"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Send(byte[] send, Func<byte[], bool> Analysis, out Exception exception);
    }
    /// <summary>
    /// 触发式模型接口
    /// </summary>
    internal interface ITalkReadModel : ITalkModel, IDisposable
    {
        /// <summary>
        /// 接收到发来的消息
        /// </summary>
        event Action<byte[]> Received;
        event Action<byte[], Exception> SendError;
        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        bool Send(byte[] aryData);
    }
    #region // 顺序读模型
    /// <summary>
    /// 对话模型
    /// </summary>
    internal class TalkQueueModel : ITalkQueueModel
    {
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
        public virtual bool Connect(out string message)
        {
            message = "接口未实现";
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
    internal class TcpTalkQueueModel : TalkQueueModel, ITalkQueueModel
    {
        IPAddress _ip;
        int _port;
        TcpClient _client;
        Stream _stream;
        bool _isConnected;
        public TcpTalkQueueModel()
        {
            _ip = IPAddress.Parse("192.168.0.178");
            _port = 4001;
            _client = new TcpClient();
        }
        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        public override bool Connect(out string message)
        {
            if (TryConnect(_ip, _port, out Exception exception))
            {
                message = String.Empty;
                return true;
            }
            message = exception.Message;
            return false;
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
            if (TryConnect(ipAddress, port, out Exception exception))
            {
                message = String.Empty;
                return true;
            }
            message = exception.Message;
            return false;
        }
        private bool TryConnect(IPAddress ipAddress, int port, out Exception exception)
        {
            try
            {
                _client.Close();
            }
            catch { }
            try
            {
                _ip = ipAddress;
                _port = port;
                _client = new TcpClient();
                _client.ReceiveTimeout = _client.SendTimeout = ReadSetter.Current.QueuePollTimeout;
                _client.Connect(ipAddress, port);
                _stream = _client.GetStream();    // 获取连接至远程的流
                exception = null;
                return _isConnected = true;
            }
            catch (Exception ex)
            {
                exception = ex;
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
            var interval = ReadSetter.Current.QueuePollTimeout;
            var waiter = ReadSetter.Current.QueuePollTimeWaiter;
            var buffLen = ReadSetter.Current.QueuePollBuffLength;
            // 获取锁定发送
            if (Monitor.TryEnter(LockObject, TimeSpan.FromMilliseconds(interval)))
            {
                if (!IsConnected) // 未连接重连尝试
                {
                    if (!TryConnect(_ip, _port, out exception))
                    {
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
                try
                {
                    lock (_stream)
                    {
                        _stream.Write(send, 0, send.Length);
                    }
                }
                catch (Exception ex)
                {
                    exception = new Exception("未连接或已经断开连接", ex);
                    received = null;
                    _isConnected = false;
                    Monitor.Exit(LockObject);
                    return false;
                }
                Thread.Sleep(waiter * 2); // 发送成功后等待,确保已经开始接收,减少出错
                var len = 0;
                var buffer = new byte[buffLen];
                try
                {
                    len = _stream.Read(buffer, 0, buffer.Length);
                    if (len > 0)
                    {
                        exception = new Exception($"已完成数据接收");
                        received = new byte[len];
                        Array.Copy(buffer, received, len);
                        Monitor.Exit(LockObject);
                        return true;
                    }
                    else
                    {
                        exception = new Exception($"未完成数据接收");
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                    if (len > 0)
                    {
                        received = new byte[len];
                        Array.Copy(buffer, received, len);
                        Monitor.Exit(LockObject);
                        return true; // 有数据就走成功逻辑
                    }
                    else
                    {
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
            }
            else
            {
                exception = new TimeoutException($"已超过轮询时间{interval}毫秒未获取到资源");
                received = null;
                return false;
            }
        }
        /// <summary>
        /// 是连接
        /// </summary>
        /// <returns></returns>
        public override bool IsConnected { get => _isConnected && _client.Connected; }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public override bool Disconnect()
        {
            return true;
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
    internal class SerialTalkQueueModel : TalkQueueModel, ITalkQueueModel
    {
        SerialPort serialPort;
        public SerialTalkQueueModel()
        {
            serialPort = new SerialPort();
        }
        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        public override bool Connect(out string message)
        {
            return Connect(serialPort.PortName, serialPort.BaudRate, out message);
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
                serialPort.ReadTimeout = ReadSetter.Current.QueuePollTimeout;
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
                message = $"端口{portName}不可用";
                return false;
            }
            catch (Exception ex)
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
            var interval = ReadSetter.Current.QueuePollTimeout;
            var waiter = ReadSetter.Current.QueuePollTimeWaiter;
            var buffLen = ReadSetter.Current.QueuePollBuffLength;
            // 获取锁定发送
            if (Monitor.TryEnter(LockObject, TimeSpan.FromMilliseconds(interval)))
            {
                if (!serialPort.IsOpen)
                {
                    received = null;
                    exception = new Exception("串口通信未初始化或未打开串口");
                    Monitor.Exit(LockObject);
                    return false;
                }
                try
                {
                    serialPort.Write(aryBuffer, 0, aryBuffer.Length);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    received = null;
                    Monitor.Exit(LockObject);
                    return false;
                }
                Thread.Sleep(waiter * 2); // 发送成功后等待,确保已经开始接收,减少出错
                var len = 0;
                var buffer = new byte[buffLen];
                var now = DateTime.Now;
                try
                {
                    while (true)
                    {
                        if ((DateTime.Now - now).TotalMilliseconds > interval)
                        {
                            bool res;
                            if (len > 0)
                            {
                                received = new byte[len];
                                Array.Copy(buffer, received, len);
                                res = true;
                                exception = new Exception($"已超过轮询时间{interval}毫秒，数据可能不完整");
                            }
                            else
                            {
                                res = false;
                                received = null;
                                exception = new Exception($"已超过轮询时间{interval}毫秒，未读取到数据");
                            }
                            Monitor.Exit(LockObject);
                            return res;
                        }
                        int nCount = serialPort.BytesToRead;
                        if (nCount == 0)
                        {
                            if (len > 0)
                            {
                                exception = new Exception($"已完成数据接收");
                                received = new byte[len];
                                Array.Copy(buffer, received, len);
                                Monitor.Exit(LockObject);
                                return true;
                            }
                            //else
                            //{
                            //    exception = new Exception($"未完成数据接收");
                            //    received = null;
                            //    Monitor.Exit(LockObject);
                            //    return false;
                            //}
                            Thread.Sleep(waiter);
                            continue;
                        }
                        serialPort.Read(buffer, len, nCount);
                        len += nCount;
                        Thread.Sleep(waiter * 2);
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                    if (len > 0)
                    {
                        received = new byte[len];
                        Array.Copy(buffer, received, len);
                        Monitor.Exit(LockObject);
                        return true; // 有数据就走成功逻辑
                    }
                    else
                    {
                        received = null;
                        Monitor.Exit(LockObject);
                        return false;
                    }
                }
            }
            else
            {
                exception = new TimeoutException($"已超过轮询时间{interval}毫秒未获取到资源");
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
    #endregion 顺序读模型
    #region // 触发读模型
    /// <summary>
    /// 对话模型
    /// </summary>
    internal class TalkReadModel : ITalkReadModel
    {
        public virtual event Action<byte[]> Received;
        public virtual event Action<byte[], Exception> SendError;

        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        public virtual bool Connect(out string message)
        {
            message = "接口未实现";
            return false;
        }
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
        /// 退出
        /// </summary>
        public virtual bool Disconnect()
        {
            return true;
        }
        /// <summary>
        /// 已连接
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnected { get => false; }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <returns></returns>
        public virtual bool Send(byte[] aryBuffer)
        {
            return false;
        }
    }
    /// <summary>
    /// TCP连接模型
    /// </summary>
    internal class TcpTalkReadModel
        : TalkReadModel, ITalkReadModel
    {
        public override event Action<byte[]> Received;
        public override event Action<byte[], Exception> SendError;
        TcpClient _client;
        Stream _stream;
        private Thread _thread;
        private bool _isConnect = false;
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

                //建立线程收取服务器发送数据
                ThreadStart stThead = new(ReceivedData);
                _thread = new Thread(stThead)
                {
                    IsBackground = true
                };
                _thread.Start();

                _isConnect = true;
                return true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                _isConnect = false;
                return false;
            }
        }

        private void ReceivedData()
        {
            while (true)
            {
                try
                {
                    byte[] btAryBuffer = new byte[4096];
                    int nLenRead = _stream.Read(btAryBuffer, 0, btAryBuffer.Length);
                    if (nLenRead == 0) { continue; }
                    if (Received != null)
                    {
                        byte[] btAryReceiveData = new byte[nLenRead];
                        Array.Copy(btAryBuffer, btAryReceiveData, nLenRead);
                        Received(btAryReceiveData);
                    }
                }
                catch (ThreadInterruptedException) // 程序中断
                {
                    break;
                }
                catch (ThreadAbortException) // 取消
                {
                    break;
                }
                catch { }
            }
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <returns></returns>
        public override bool Send(byte[] aryBuffer)
        {
            try
            {
                if (!_isConnect) { return false; }
                lock (_stream)
                {
                    _stream.Write(aryBuffer, 0, aryBuffer.Length);
                    return true;
                }
            }
            catch
            {
                _isConnect = false;
                return false;
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        public override bool Disconnect()
        {
            _stream?.Dispose();
            _client?.Close();
            try
            {
                _thread?.Abort();
            }
            catch { }
            try
            {
                _thread?.Interrupt();
            }
            catch { }
            _thread = null;
            _isConnect = false;
            return true;
        }
        /// <summary>
        /// 是连接
        /// </summary>
        /// <returns></returns>
        public override bool IsConnected { get => _isConnect && _client.Connected; }
        public override void Dispose()
        {
            base.Dispose();
            Disconnect();
        }
    }
    /// <summary>
    /// 串口连接模型
    /// </summary>
    internal class SerialTalkReadModel : TalkReadModel, ITalkReadModel
    {
        public override event Action<byte[], Exception> SendError;
        public override event Action<byte[]> Received;
        SerialPort _serialPort;
        public SerialTalkReadModel()
        {
            _serialPort = new SerialPort();
            _serialPort.DataReceived += ISerialPort_DataReceived;
        }

        private void ISerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int nCount = _serialPort.BytesToRead;
                if (nCount == 0) { return; }
                byte[] btAryBuffer = new byte[nCount];
                _serialPort.Read(btAryBuffer, 0, nCount);
                Received?.Invoke(btAryBuffer);
            }
            catch { }
        }

        public override bool Connect(string portName, int bautRate, out string message)
        {
            message = string.Empty;
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            try
            {
                _serialPort.PortName = portName;
                _serialPort.BaudRate = bautRate;
                _serialPort.ReadTimeout = 200;
                _serialPort.Open();
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }

        public override bool Disconnect()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            return true;
        }

        public override bool IsConnected { get => _serialPort.IsOpen; }

        public override bool Send(byte[] aryBuffer)
        {
            if (!_serialPort.IsOpen) { return false; }
            _serialPort.Write(aryBuffer, 0, aryBuffer.Length);
            return true;
        }
        public override void Dispose()
        {
            base.Dispose();
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            _serialPort.Dispose();
        }
    }
    #endregion
    #region // 逻辑跳读模型
    /// <summary>
    /// TCP连接模型
    /// </summary>
    internal class TcpLogicalTalkModel : TalkReadModel, ITalkReadModel
    {
        public override event Action<byte[]> Received;
        public override event Action<byte[], Exception> SendError;
        private byte[] _buffer;
        private int _len;
        private TcpClient _client;
        private Stream _stream;
        private Thread _thread;
        private bool _isConnected = false;
        public TcpLogicalTalkModel()
        {
            _buffer = new byte[1024];
            _len = 0;
            //建立线程收取服务器发送数据
            _thread = new Thread(ReceivedData)
            {
                IsBackground = true
            };
            _thread.Start();
        }
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
            catch (System.Exception ex)
            {
                message = ex.Message;
                _isConnected = false;
                return false;
            }
        }
        private void ReceivedData()
        {
            while (true)
            {
                try
                {
                    if (!_isConnected)
                    {
                        Thread.Sleep(30);
                        continue;
                    }
                    var tmpBuffer = new byte[1024];
                    int nCount = _stream.Read(tmpBuffer, 0, tmpBuffer.Length);
                    if (nCount > 0)
                    {
                        if (_buffer.Length < nCount + _len)
                        {
                            var temp = new byte[nCount + _len];
                            Array.Copy(_buffer, 0, temp, 0, _buffer.Length);
                            _buffer = temp;
                        }
                        Array.Copy(tmpBuffer, 0, _buffer, _len, nCount);
                        _len += nCount;
                    }
                    if (_len == 0) { continue; }
                    int dstart = -1;
                    // 判断接收位置:
                    for (int i = 0; i < _len; i++)
                    {
                        if (_buffer[i] == 0xA0)
                        {
                            dstart = i;
                            break;
                        }
                    }
                    if (dstart == -1) { continue; }
                    int dlen = Convert.ToInt32(_buffer[dstart + 1]);
                    if (dstart + 1 + dlen < _len)
                    {
                        byte[] res = new byte[dlen + 2];
                        Array.Copy(_buffer, dstart, res, 0, dlen + 2);
                        var length = 1024 > _buffer.Length ? 1024 : _buffer.Length;
                        var tmp = new byte[length];
                        Array.Copy(_buffer, dstart + res.Length, tmp, 0, _buffer.Length - dstart + res.Length);
                        _buffer = tmp;
                        _len -= (dstart + res.Length);
                        Task.Factory.StartNew(() => Received?.Invoke(res));
                    }
                    Thread.Sleep(20);
                }
                catch (ThreadInterruptedException) // 程序中断
                {
                    break;
                }
                catch (ThreadAbortException) // 取消
                {
                    break;
                }
                catch { }
            }
        }
        public override bool Send(byte[] aryBuffer)
        {
            try
            {
                if (!_isConnected) { return false; }
                lock (_stream)
                {
                    _stream.Write(aryBuffer, 0, aryBuffer.Length);
                    return true;
                }
            }
            catch
            {
                _isConnected = false;
                return false;
            }
        }
        public override bool Disconnect()
        {
            _stream?.Dispose();
            _client?.Close();
#if NETFrame
            _thread.Abort();
#else
            _thread.Interrupt();
            _thread.Join();
#endif
            _isConnected = false;
            return true;
        }
        public override bool IsConnected { get => _isConnected && _client.Connected; }
        public override void Dispose()
        {
            base.Dispose();
            Disconnect();
        }
    }
    /// <summary>
    /// 串口连接模型
    /// </summary>
    internal class SerialLogicalTalkModel : TalkReadModel, ITalkReadModel
    {
        public override event Action<byte[]> Received;
        public override event Action<byte[], Exception> SendError;
        private byte[] _buffer;
        private int _len;
        private SerialPort _serialPort;
        private Thread _thread;
        private bool _isConnected;
        public SerialLogicalTalkModel()
        {
            _serialPort = new SerialPort();
            _buffer = new byte[1024];
            //建立线程收取服务器发送数据
            _thread = new Thread(ReceivedData)
            {
                IsBackground = true
            };
            _thread.Start();
        }

        private void ReceivedData()
        {
            while (true)
            {
                try
                {
                    if (!_isConnected)
                    {
                        Thread.Sleep(30);
                        continue;
                    }
                    int nCount = _serialPort.BytesToRead;
                    if (nCount > 0)
                    {
                        if (_buffer.Length < nCount + _len)
                        {
                            var temp = new byte[nCount];
                            Array.Copy(_buffer, 0, temp, 0, _buffer.Length);
                            _buffer = temp;
                        }
                        _serialPort.Read(_buffer, _len, nCount);
                        _len += nCount;
                    }
                    if (_len == 0)
                    {
                        Thread.Sleep(20);
                        continue;
                    }
                    int dstart = -1;
                    // 判断接收位置:
                    for (int i = 0; i < _len; i++)
                    {
                        if (_buffer[i] == 0xA0)
                        {
                            dstart = i;
                            break;
                        }
                    }
                    if (dstart == -1)
                    {
                        Thread.Sleep(20);
                        continue;
                    }
                    int dlen = Convert.ToInt32(_buffer[dstart + 1]);
                    if (dstart + 1 + dlen < _len)
                    {
                        byte[] res = new byte[dlen + 2];
                        Array.Copy(_buffer, dstart, res, 0, dlen + 2);
                        var length = 1024 > _buffer.Length ? 1024 : _buffer.Length;
                        var tmp = new byte[length];
                        Array.Copy(_buffer, dstart + res.Length, tmp, 0, _buffer.Length - dstart - res.Length);
                        _buffer = tmp;
                        _len -= (dstart + res.Length);
                        Task.Factory.StartNew(() => Received?.Invoke(res));
                    }
                    Thread.Sleep(20);
                }
                catch (ThreadInterruptedException) // 程序中断
                {
                    break;
                }
                catch (ThreadAbortException) // 取消
                {
                    break;
                }
                catch { }
            }
        }
        public override bool Connect(string portName, int bautRate, out string message)
        {
            message = string.Empty;
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            try
            {
                _serialPort.PortName = portName;
                _serialPort.BaudRate = bautRate;
                _serialPort.ReadTimeout = 200;
                _serialPort.Open();

                _isConnected = true;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                _isConnected = false;
                return false;
            }
            return true;
        }
        public override bool Disconnect()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            return true;
        }
        public override bool IsConnected { get => _isConnected && _serialPort.IsOpen; }
        public override bool Send(byte[] aryData)
        {
            if (!_serialPort.IsOpen)
            {
                SendError?.Invoke(aryData, new IOException($"当前串口[{_serialPort.PortName}]未打开"));
                _isConnected = false;
                return false;
            }
            try
            {
                _serialPort.Write(aryData, 0, aryData.Length);
                _isConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SendError?.Invoke(aryData, ex);
                return false;
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            _isConnected = false;
            _thread.Interrupt();
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            _serialPort.Dispose();
        }
    }
    #endregion
}
