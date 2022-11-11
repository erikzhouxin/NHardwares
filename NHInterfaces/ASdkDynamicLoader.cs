using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HardwareInterfaces
{
    /// <summary>
    /// LoadLibraryFlags加载动态链接库标记
    /// </summary>
    public enum SdkDynamicLoadLibFlags : uint
    {
        /// <summary>
        /// 这个标志用于告诉系统将DLL映射到调用进程的地址空间中，
        /// 但是不调用DllMain并且不加载依赖Dll（只映射自己本身）。
        /// </summary>
        DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

        /// <summary>
        /// LOAD_IGNORE_CODE_AUTHZ_LEVEL
        /// </summary>
        LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

        /// <summary>
        /// 这个标志与DONT_RESOLVE_DLL_REFERENCES标志相类似，
        /// 因为系统只是将DLL映射到进程的地址空间中，就像它是数据文件一样。
        /// 系统并不花费额外的时间来准备执行文件中的任何代码。
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
        /// 应用程序安装路径搜索Dll和其依赖项。
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
        /// 从%windows%\system32加载Dll和其依赖项。
        /// </summary>
        LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

        /// <summary>
        /// 搜索路径的使用使用AddDllDirectory和SetDllDirectory设置的路径（保护Dll自己和依赖Dll）。
        /// </summary>
        LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

        /// <summary>
        /// 让系统dll得搜索顺序从当前dll目录下开始，该方法会强制加载该dll关联得同目录下得所有dll，
        /// 例如A.dll 依赖同目录下得 B.dll ，系统目录下也有B.dll，
        /// 则使用LoadLibraryEx（A.dll, NULL, LOAD_WITH_ALTERED_SEARCH_PATH）避免加载到系统目录下得B.dll
        /// 按照如下目录搜索：
        /// 1.进程当前目录。
        /// 2.Windows的系统目录。
        /// 3.16 位Windows的系统目录。
        /// 4.Windows目录。
        /// 5.path环境变量目录。
        /// </summary>
        LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
    }
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
