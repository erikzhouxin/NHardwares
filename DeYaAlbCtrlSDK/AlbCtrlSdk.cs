using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
using System.IO;
using System.Linq;
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
        /// 基础全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 基础文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\albctrlsdk";
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
        /// 静态构造
        /// </summary>
        static AlbCtrlSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_ALBCtrlDll))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_ALBCtrlDll, Path.Combine(DllFullPath, "ALBCtrlDll.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_ALBCtrlDll))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_ALBCtrlDll, Path.Combine(DllFullPath, "ALBCtrlDll.dll"));
                }
            }
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
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return AlbCtrlSdkDller.Instance;
        }
    }
}
