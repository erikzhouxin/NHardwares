using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace System.Data.NSerialPort
{
    /// <summary>
    /// 串口读操作接口
    /// </summary>
    public interface ISerialPortTalkModel : IDisposable
    {
        /// <summary>
        /// 错误回调
        /// </summary>
        Action<byte[], Exception> Errored { get; set; }
        /// <summary>
        /// 错误回调
        /// </summary>
        Action<byte[]> Received { get; set; }
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        bool Disconnect();
        /// <summary>
        /// 是连接
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <returns></returns>
        bool Send(byte[] aryBuffer);
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <returns></returns>
        bool Connect(out Exception exception);
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Connect(ISerialPortConfigModel model, out Exception exception);
        /// <summary>
        /// 配置项
        /// </summary>
        ISerialPortConfigModel Config { get; }
    }
    /// <summary>
    /// 串口连接模型
    /// </summary>
    internal class SerialPortTalkModel : ISerialPortTalkModel
    {
        SerialPort _serialPort;
        ISerialPortConfigModel _config;
        public SerialPortTalkModel()
        {
            _serialPort = new SerialPort();
        }
        public SerialPortTalkModel(ISerialPortConfigModel talk) : this()
        {
            _config = talk;
        }
        public virtual ISerialPortConfigModel Config { get => _config; }
        public virtual Action<byte[], Exception> Errored { get; set; }
        public virtual Action<byte[]> Received { get; set; }
        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Errored?.Invoke(new byte[0], new Exception($"{_config.PortName}:{_config.PortRate} => {e.EventType}"));
        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int nCount = _serialPort.BytesToRead;
                if (nCount == 0) { return; }
                byte[] btAryBuffer = new byte[nCount];
                _serialPort.Read(btAryBuffer, 0, nCount);
                Received?.Invoke(btAryBuffer);
            }
            catch (Exception ex)
            {
                Errored?.Invoke(new byte[0], ex);
            }
        }
        public virtual bool Connect(out Exception exception)
        {
            if (_config == null)
            {
                exception = new ArgumentNullException("未找到初始化配置项内容");
                return false;
            }
            return Connect(_config, out exception);
        }
        public virtual bool Connect(ISerialPortConfigModel model, out Exception exception)
        {
            try
            {
                _config = model;
                if (_serialPort.IsOpen) { _serialPort.Close(); }
                _serialPort.PortName = model.PortName;
                _serialPort.BaudRate = model.PortRate;
                if (model.ReadTimeout > 0)
                { _serialPort.ReadTimeout = model.ReadTimeout; }
                if (model.StopBits > StopBitsType.Unknown)
                { _serialPort.StopBits = (StopBits)(int)model.StopBits; }
                if (model.DataBits > DataBitsType.Unknown)
                { _serialPort.DataBits = (int)model.DataBits; }
                if (model.Parity > DataParityType.Unknown)
                { _serialPort.Parity = (Parity)(int)model.Parity; }
                if (model.ThresholdLen > 0)
                { _serialPort.ReceivedBytesThreshold = model.ThresholdLen; }
                _serialPort.DataReceived -= DataReceived;
                _serialPort.ErrorReceived -= ErrorReceived;
                _serialPort.DataReceived += DataReceived;
                _serialPort.ErrorReceived += ErrorReceived;
                _serialPort.Open();
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }
        public virtual bool Disconnect()
        {
            if (_serialPort.IsOpen)
            { _serialPort.Close(); }
            return true;
        }
        public virtual bool IsConnected { get => _serialPort.IsOpen; }
        public virtual bool Send(byte[] aryBuffer)
        {
            if (!_serialPort.IsOpen) { return false; }
            try
            {
                _serialPort.Write(aryBuffer, 0, aryBuffer.Length);
            }
            catch (Exception ex)
            {
                Errored?.Invoke(aryBuffer, new IOException($"{_config.PortName}:{_config.PortRate} => 写入失败，原因是：{ex.Message}", ex));
                return false;
            }
            return true;
        }
        public virtual void Dispose()
        {
            if (_serialPort.IsOpen)
            { _serialPort.Close(); }
            _serialPort.Dispose();
        }
    }
}
