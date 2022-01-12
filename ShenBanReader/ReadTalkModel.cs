﻿using System;
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
    internal interface ReadTalkModel : IDisposable
    {
        /// <summary>
        /// 接收到发来的消息
        /// </summary>
        event Action<byte[]> Received;
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
        /// 发送数据包
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <returns></returns>
        bool Send(byte[] aryBuffer);
        /// <summary>
        /// 注销连接
        /// </summary>
        void Exit();
        /// <summary>
        /// 校验是否连接服务器
        /// </summary>
        /// <returns></returns>
        bool IsConnect();
    }
    #region // 顺序读模型
    /// <summary>
    /// 对话模型接口
    /// </summary>
    internal interface ITalkQueueModel : IDisposable
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
                _client.ReceiveTimeout = _client.SendTimeout = ReaderSetter.Current.ReadPollTimeout;
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
            var interval = ReaderSetter.Current.ReadPollTimeout;
            var waiter = ReaderSetter.Current.ReadPollTimeWaiter;
            var buffLen = ReaderSetter.Current.ReadPollBuffLength;
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
    internal class SerialTalkQueueModel : TalkQueueModel, ITalkQueueModel
    {
        SerialPort serialPort;
        public SerialTalkQueueModel()
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
                serialPort.ReadTimeout = ReaderSetter.Current.ReadPollTimeout;
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
            var interval = ReaderSetter.Current.ReadPollTimeout;
            var waiter = ReaderSetter.Current.ReadPollTimeWaiter;
            var buffLen = ReaderSetter.Current.ReadPollBuffLength;
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
                            else
                            {
                                exception = new Exception($"未完成数据接收");
                                received = null;
                                Monitor.Exit(LockObject);
                                return false;
                            }
                        }
                        serialPort.Read(buffer, len, nCount);
                        len += nCount;
                        Thread.Sleep(waiter);
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
}
