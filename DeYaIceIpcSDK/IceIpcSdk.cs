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
        /// 全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\iceipcsdk";
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
        /// 静态构造
        /// </summary>
        static IceIpcSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_ice_ipcsdk))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_ice_ipcsdk, Path.Combine(DllFullPath, "ice_ipcsdk.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avutil_52, Path.Combine(DllFullPath, "avutil-52.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_draw, Path.Combine(DllFullPath, "draw.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_hi_h264dec_w64, Path.Combine(DllFullPath, "hi_h264dec_w64.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_ice_p2p, Path.Combine(DllFullPath, "ice_p2p.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_Packet, Path.Combine(DllFullPath, "Packet.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_swscale_2, Path.Combine(DllFullPath, "swscale-2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_wpcap, Path.Combine(DllFullPath, "wpcap.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_ice_ipcsdk))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_ice_ipcsdk, Path.Combine(DllFullPath, "ice_ipcsdk.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_avutil_52, Path.Combine(DllFullPath, "avutil-52.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_draw, Path.Combine(DllFullPath, "draw.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_hi_h264dec_w, Path.Combine(DllFullPath, "hi_h264dec_w.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_ice_p2p, Path.Combine(DllFullPath, "ice_p2p.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_Packet, Path.Combine(DllFullPath, "Packet.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_swscale_2, Path.Combine(DllFullPath, "swscale-2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_wpcap, Path.Combine(DllFullPath, "wpcap.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));
                }
            }
        }
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
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return IceIpcSdkDller.Instance;
        }
    }
}
