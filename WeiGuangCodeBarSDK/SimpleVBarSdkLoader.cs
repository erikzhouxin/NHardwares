using System.IO;
using System.Runtime.InteropServices;
using System.Data.NHInterfaces;

namespace System.Data.WeiGuangCodeBarSDK
{
    internal class SimpleVBarSdkLoader : ASdkDynamicLoader, ISimpleVBarSdkProxy
    {
        #region // 委托定义        
        private DCreater.vbar_channel_close _vbar_channel_close;
        private DCreater.vbar_channel_open _vbar_channel_open;
        private DCreater.vbar_channel_recv _vbar_channel_recv;
        private DCreater.vbar_channel_send _vbar_channel_send;
        #endregion 委托定义
        public SimpleVBarSdkLoader()
        {
            _vbar_channel_close = GetDelegate<DCreater.vbar_channel_close>(nameof(DCreater.vbar_channel_close));
            _vbar_channel_open = GetDelegate<DCreater.vbar_channel_open>(nameof(DCreater.vbar_channel_open));
            _vbar_channel_recv = GetDelegate<DCreater.vbar_channel_recv>(nameof(DCreater.vbar_channel_recv));
            _vbar_channel_send = GetDelegate<DCreater.vbar_channel_send>(nameof(DCreater.vbar_channel_send));
        }
        /// <inheritdoc />
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? SimpleVBarSdk.DllFileNameX64 : SimpleVBarSdk.DllFileNameX86);
        }
        #region // 显示实现
        void ISimpleVBarSdkProxy.Vbar_channel_close(IntPtr dev) => _vbar_channel_close.Invoke(dev);
        IntPtr ISimpleVBarSdkProxy.Vbar_channel_open(int type, long parm) => _vbar_channel_open.Invoke(type, parm);
        int ISimpleVBarSdkProxy.Vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds) => _vbar_channel_recv.Invoke(dev, buffer, size, milliseconds);
        int ISimpleVBarSdkProxy.Vbar_channel_send(IntPtr dev, byte[] data, int length) => _vbar_channel_send.Invoke(dev, data, length);
        #endregion
    }
}
