using System;
using System.Collections.Generic;
using System.Data.NSerialPort;
using System.Linq;
using System.Text;

namespace System.Data.RecBarCodeModule
{
    /// <summary>
    /// 二维码识别代理
    /// </summary>
    public interface IRecBarCodeProxy : ISerialPortTalkModel
    {

    }
    internal class RecBarCodeModuleProxy : IRecBarCodeProxy
    {
        private readonly ISerialPortTalkModel _proxy;
        public RecBarCodeModuleProxy(ISerialPortTalkModel proxy)
        {
            _proxy = proxy;
        }
        public Action<byte[], Exception> Errored { get => _proxy.Errored; set => _proxy.Errored = value; }
        public Action<byte[]> Received { get => _proxy.Received; set => _proxy.Received = value; }

        public bool IsConnected => _proxy.IsConnected;

        public ISerialPortConfigModel Config => _proxy.Config;

        public bool Connect(out Exception exception)
        {
            return _proxy.Connect(out exception);
        }

        public bool Connect(ISerialPortConfigModel model, out Exception exception)
        {
            return _proxy.Connect(model, out exception);
        }

        public bool Disconnect()
        {
            return _proxy.Disconnect();
        }

        public void Dispose()
        {
            _proxy.Dispose();
        }

        public bool Send(byte[] aryBuffer)
        {
            return _proxy.Send(aryBuffer);
        }
    }
}
