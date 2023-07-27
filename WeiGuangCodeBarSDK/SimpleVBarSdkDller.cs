using System.IO;
using System.Runtime.InteropServices;

namespace System.Data.WeiGuangCodeBarSDK
{
    internal class SimpleVBarSdkDllerX64 : ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static ISimpleVBarSdkProxy Instance { get; } = new SimpleVBarSdkDllerX64();
        private SimpleVBarSdkDllerX64() { }
        //打开信道
        [DllImport(SimpleVBarSdk.DllFileNameX64, EntryPoint = "vbar_channel_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vbar_channel_open(int type, long parm);
        //发送数据
        [DllImport(SimpleVBarSdk.DllFileNameX64, EntryPoint = "vbar_channel_send", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_send(IntPtr dev, byte[] data, int length);
        //接收数据
        [DllImport(SimpleVBarSdk.DllFileNameX64, EntryPoint = "vbar_channel_recv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        //关闭信道
        [DllImport(SimpleVBarSdk.DllFileNameX64, EntryPoint = "vbar_channel_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vbar_channel_close(IntPtr dev);
        #region // 显示实现
        void ISimpleVBarSdkProxy.Vbar_channel_close(IntPtr dev) => vbar_channel_close(dev);
        IntPtr ISimpleVBarSdkProxy.Vbar_channel_open(int type, long parm) => vbar_channel_open(type, parm);
        int ISimpleVBarSdkProxy.Vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds) => vbar_channel_recv(dev, buffer, size, milliseconds);
        int ISimpleVBarSdkProxy.Vbar_channel_send(IntPtr dev, byte[] data, int length) => vbar_channel_send(dev, data, length);
        #endregion
    }
    internal class SimpleVBarSdkDllerX86 : ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static ISimpleVBarSdkProxy Instance { get; } = new SimpleVBarSdkDllerX86();
        private SimpleVBarSdkDllerX86() { }
        //打开信道
        [DllImport(SimpleVBarSdk.DllFileNameX86, EntryPoint = "vbar_channel_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vbar_channel_open(int type, long parm);
        //发送数据
        [DllImport(SimpleVBarSdk.DllFileNameX86, EntryPoint = "vbar_channel_send", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_send(IntPtr dev, byte[] data, int length);
        //接收数据
        [DllImport(SimpleVBarSdk.DllFileNameX86, EntryPoint = "vbar_channel_recv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        //关闭信道
        [DllImport(SimpleVBarSdk.DllFileNameX86, EntryPoint = "vbar_channel_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vbar_channel_close(IntPtr dev);
        #region // 显示实现
        void ISimpleVBarSdkProxy.Vbar_channel_close(IntPtr dev) => vbar_channel_close(dev);
        IntPtr ISimpleVBarSdkProxy.Vbar_channel_open(int type, long parm) => vbar_channel_open(type, parm);
        int ISimpleVBarSdkProxy.Vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds) => vbar_channel_recv(dev, buffer, size, milliseconds);
        int ISimpleVBarSdkProxy.Vbar_channel_send(IntPtr dev, byte[] data, int length) => vbar_channel_send(dev, data, length);
        #endregion
    }
}
