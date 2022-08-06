using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 简单微光条码识别代理
    /// </summary>
    public interface ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 打开信道
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        IntPtr vbar_channel_open(int type, long parm);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        int vbar_channel_send(IntPtr dev, byte[] data, int length);
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        int vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        /// <summary>
        /// 关闭信道
        /// </summary>
        /// <param name="dev"></param>
        void vbar_channel_close(IntPtr dev);
    }
    internal class SimpleVBarSdkDller : ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static ISimpleVBarSdkProxy Instance { get; } = new SimpleVBarSdkDller();
        private SimpleVBarSdkDller() { }
        public const String DllFileName = "vbar.dll";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.GetFullPath(DllFileName);
        //打开信道
        [DllImport(DllFileName, EntryPoint = "vbar_channel_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr vbar_channel_open(int type, long parm);
        //发送数据
        [DllImport(DllFileName, EntryPoint = "vbar_channel_send", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_send(IntPtr dev, byte[] data, int length);
        //接收数据
        [DllImport(DllFileName, EntryPoint = "vbar_channel_recv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        //关闭信道
        [DllImport(DllFileName, EntryPoint = "vbar_channel_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void vbar_channel_close(IntPtr dev);
        #region // 显示实现
        void ISimpleVBarSdkProxy.vbar_channel_close(IntPtr dev) => vbar_channel_close(dev);
        IntPtr ISimpleVBarSdkProxy.vbar_channel_open(int type, long parm) => vbar_channel_open(type, parm);
        int ISimpleVBarSdkProxy.vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds) => vbar_channel_recv(dev, buffer, size, milliseconds);
        int ISimpleVBarSdkProxy.vbar_channel_send(IntPtr dev, byte[] data, int length) => vbar_channel_send(dev, data, length);
        #endregion
    }
    internal class SimpleVBarSdkLoader : ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllPath = @"plugins\simplevbarsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(Path.GetFullPath(DllPath), SimpleVBarSdkDller.DllFileName);
        #region // 委托定义        
        private DCreater.vbar_channel_close _vbar_channel_close;
        private DCreater.vbar_channel_open _vbar_channel_open;
        private DCreater.vbar_channel_recv _vbar_channel_recv;
        private DCreater.vbar_channel_send _vbar_channel_send;
        #endregion
        public SimpleVBarSdkLoader()
        {
            hModule = LoadLibraryEx(DllFullName, IntPtr.Zero, LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);

            _vbar_channel_close = GetDelegate<DCreater.vbar_channel_close>(nameof(DCreater.vbar_channel_close));
            _vbar_channel_open = GetDelegate<DCreater.vbar_channel_open>(nameof(DCreater.vbar_channel_open));
            _vbar_channel_recv = GetDelegate<DCreater.vbar_channel_recv>(nameof(DCreater.vbar_channel_recv));
            _vbar_channel_send = GetDelegate<DCreater.vbar_channel_send>(nameof(DCreater.vbar_channel_send));
        }
        #region // 动态内容
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();
        /// <summary>
        /// API LoadLibraryEx
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="hReservedNull"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryEx", SetLastError = true)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr LoadLibrary(string lpFileName, int h, int flags);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lProcName);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool FreeLibrary(IntPtr hModule);
        IntPtr hModule;
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            FreeLibrary(hModule);
        }
        public Delegate GetMethod(string procName, Type type)
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(func, type);
        }
        public T GetDelegate<T>(string procName) where T : Delegate
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (T)Marshal.GetDelegateForFunctionPointer(func, typeof(T));
        }
        /// <summary>
        /// LoadLibraryFlags
        /// </summary>
        public enum LoadLibraryFlags : uint
        {
            /// <summary>
            /// DONT_RESOLVE_DLL_REFERENCES
            /// </summary>
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

            /// <summary>
            /// LOAD_IGNORE_CODE_AUTHZ_LEVEL
            /// </summary>
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

            /// <summary>
            /// LOAD_LIBRARY_AS_IMAGE_RESOURCE
            /// </summary>
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_APPLICATION_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DEFAULT_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_SYSTEM32
            /// </summary>
            LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_USER_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

            /// <summary>
            /// LOAD_WITH_ALTERED_SEARCH_PATH
            /// </summary>
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }
        #endregion
        #region // 显示实现
        void ISimpleVBarSdkProxy.vbar_channel_close(IntPtr dev) => _vbar_channel_close.Invoke(dev);
        IntPtr ISimpleVBarSdkProxy.vbar_channel_open(int type, long parm) => _vbar_channel_open.Invoke(type, parm);
        int ISimpleVBarSdkProxy.vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds) => _vbar_channel_recv.Invoke(dev, buffer, size, milliseconds);
        int ISimpleVBarSdkProxy.vbar_channel_send(IntPtr dev, byte[] data, int length) => _vbar_channel_send.Invoke(dev, data, length);
        #endregion
    }
}
