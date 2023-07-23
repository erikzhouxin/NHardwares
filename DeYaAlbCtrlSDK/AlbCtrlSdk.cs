using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.DeYaAlbCtrlSDK
{
    /// <summary>
    /// 德亚道闸SDK
    /// </summary>
    public static class AlbCtrlSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "ALBCtrlDll.dll";
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\albctrlsdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// 基础全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 基础文件全路径
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
        static Lazy<IAlbCtrlSdkProxy> _albCtrlSdk = new Lazy<IAlbCtrlSdkProxy>(() => new AlbCtrlSdkLoader(), true);
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IAlbCtrlSdkProxy Instance { get => _albCtrlSdk.Value; }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IAlbCtrlSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _albCtrlSdk.Value; }
            return Environment.Is64BitProcess ? AlbCtrlSdkDllerX64.Instance : AlbCtrlSdkDllerX86.Instance;
        }
    }
}
