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
        public const string DllVirtualPath = @"plugins\deyaalbctrlsdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x64的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// SDK包相对路径
        /// </summary>
        public const String DllPackFile = $"{DllVirtualPath}.cswin";
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static string DllSdkFile { get; } = Path.GetFullPath(DllPackFile);
        /// <summary>
        /// 基础全路径
        /// </summary>
        public static string BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        static Lazy<IAlbCtrlSdkProxy> _albCtrlSdk = new Lazy<IAlbCtrlSdkProxy>(() => new AlbCtrlSdkLoader(), true);
        static AlbCtrlSdk()
        {
            var res = new SdkFileLoaderModel()
            {
                BasePath = DllFullPath,
                PlatformPath = Environment.Is64BitProcess ? "x64" : "x86",
                VersionFile = $"{nameof(DeYaAlbCtrlSDK)}.version",
                SdkFileName = DllSdkFile
            }.Build();
            if (res.IsSuccess) { return; }
            throw new Exception(res.Message, (res as IAlertException)?.Exception);
        }
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
