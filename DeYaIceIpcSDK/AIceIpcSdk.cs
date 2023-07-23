using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Data.NHInterfaces;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// SDK调用
    /// </summary>
    public static class IceIpcSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "ice_ipcsdk.dll";
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\deyaiceipcsdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        static Lazy<IIceIpcSdkProxy> _iceIpcSdk = new Lazy<IIceIpcSdkProxy>(() => new IceIpcSdkLoader(), true);
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IIceIpcSdkProxy Instance { get => _iceIpcSdk.Value; }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIceIpcSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _iceIpcSdk.Value; }
            return Environment.Is64BitProcess ? IceIpcSdkDllerX64.Instance : IceIpcSdkDllerX86.Instance;
        }
    }
}
