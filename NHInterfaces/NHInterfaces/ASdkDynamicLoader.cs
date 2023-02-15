using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.NHInterfaces
{
    /// <summary>
    /// SDK动态加载抽象类
    /// </summary>
    public abstract class ASdkDynamicLoader : IDisposable
    {
        /// <summary>
        /// 获取最后的错误
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        /// <summary>
        /// 加载类库扩展
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="hReservedNull"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryEx", SetLastError = true)]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, SdkDynamicLoadLibFlags dwFlags);
        /// <summary>
        /// 加载类库
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="h"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LoadLibrary(string lpFileName, int h, int flags);
        /// <summary>
        /// 获取函数地址
        /// </summary>
        /// <param name="hModule"></param>
        /// <param name="lProcName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lProcName);
        /// <summary>
        /// 释放类库
        /// </summary>
        /// <param name="hModule"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool FreeLibrary(IntPtr hModule);
        /// <summary>
        /// 加载类
        /// </summary>
        protected IntPtr hModule;
        /// <summary>
        /// 构造
        /// </summary>
        public ASdkDynamicLoader()
        {
            Initialize();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            FreeLibrary(hModule);
        }
        /// <summary>
        /// 获取方法委托
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual Delegate GetMethod(string procName, Type type)
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(func, type);
        }
        /// <summary>
        /// 获取泛型委托
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <returns></returns>
        public virtual T GetDelegate<T>(string procName) where T : Delegate
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (T)Marshal.GetDelegateForFunctionPointer(func, typeof(T));
        }
        /// <summary>
        /// 获取泛型委托(懒加载)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <returns></returns>
        public virtual LazyBone<T> GetLazyDelegate<T>(string procName) where T : Delegate
        {
            return new LazyBone<T>(() => GetDelegate<T>(procName), true);
        }
        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// <returns></returns>
        public abstract string GetFileFullName();
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            hModule = LoadLibraryEx(GetFileFullName(), IntPtr.Zero, SdkDynamicLoadLibFlags.LOAD_WITH_ALTERED_SEARCH_PATH);
        }
    }
}
