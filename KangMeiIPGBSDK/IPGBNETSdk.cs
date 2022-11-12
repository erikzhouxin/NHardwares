using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 康美音柱服务SDK
    /// </summary>
    public static class IPGBNETSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "IPGBNETSDK.dll";
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
        public const string DllVirtualPath = @"plugins\kangmeiipgbsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        /// <summary>
        /// 最大IP地址长度
        /// </summary>
        public const int IPGB_MAX_IPADR_LEN = 16;
        /// <summary>
        /// 最大用户名长度
        /// </summary>
        public const int IPGB_MAX_USERNAME_LEN = 60;
        /// <summary>
        /// 最大密码长度
        /// </summary>
        public const int IPGB_MAX_USERPASS_LEN = 20;
        /// <summary>
        /// 最域名长度
        /// </summary>
        public const int IPGB_MAX_DOMAIN_LEN = 128;
        /// <summary>
        /// 终端名最大长度
        /// </summary>
        public const int IPGB_MAX_TMNAME_LEN = 200;
        /// <summary>
        /// 一个节点最多可控制终端个数
        /// </summary>
        public const int IPGB_MAX_SDKTMCOUT = 3000;
        /// <summary>
        /// 一个节点最多可控制编码终端的个数
        /// </summary>
        public const int IPGB_MAX_SDKENCTMCOUT = 30;
        /// <summary>
        /// 一个文件名和目录最大长度(服务器文件源)
        /// </summary>
        public const int IPGB_MAX_FILEPATH = 60;
        /// <summary>
        /// 一个文件名和目录最大长度(本地文件源)
        /// </summary>
        public const int IPGB_MAX_LCA_FILEPATH = 250;
        /// <summary>
        /// 一次调节终端音量的最大终端个数
        /// </summary>
        public const int IPGB_MAX_SETVOL_COUT = 200;
        /// <summary>
        /// 一节点最多支持终端分区个数
        /// </summary>
        public const int IPGB_MAX_SDKFQCOUT = 50;
        /// <summary>
        /// 一个分区名最大长度
        /// </summary>
        public const int IPGB_MAX_FQNAME_LEN = 200;
        /// <summary>
        /// 一次最多可广播的文件个数
        /// </summary>
        public const int IPGB_MAX_GBFILE = 30;
        /// <summary>
        /// 电话号码最大长度
        /// </summary>
        public const int IPGB_MAX_TELEPHONELEN = 28;
        /// <summary>
        /// 声卡名称最大长度
        /// </summary>
        public const int IPGB_MAX_SoundCardNAME = 512;
        /// <summary>
        /// 系统声卡混音接口最大个数
        /// </summary>
        public const int IPGB_MAX_SoundCardMixCout = 10;
        /// <summary>
        /// TTS广播最大文件长度
        /// </summary>
        public const int IPGB_MAX_TTSTEXTLEN = 2000;
        /// <summary>
        /// 第三方消防系统信号一次输入触发数
        /// </summary>
        public const int IPGB_MAX_THREEFIRCOUT = 32;

        static Lazy<IIPGBNETSdkProxy> _IPGBNETSdk = new Lazy<IIPGBNETSdkProxy>(() => new IPGBNETSdkLoader(), true);
        static Lazy<IIPGBPUSHSdkProxy> _IPGBPUSHSdk = new Lazy<IIPGBPUSHSdkProxy>(() => new IPGBPUSHSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static IPGBNETSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_IPGBNETSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_IPGBNET, Path.Combine(DllFullPath, "IPGBNET.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_IPGBNETPush, Path.Combine(DllFullPath, "IPGBNETPush.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_IPGBNETSDK, Path.Combine(DllFullPath, "IPGBNETSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_CtlAudioDrv, Path.Combine(DllFullPath, "CtlAudioDrv.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_IPGBPushStream, Path.Combine(DllFullPath, "IPGBPushStream.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_lame_enc_dll, Path.Combine(DllFullPath, "lame_enc_dll.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libmp3lame, Path.Combine(DllFullPath, "libmp3lame.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfc100, Path.Combine(DllFullPath, "mfc100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfc100u, Path.Combine(DllFullPath, "mfc100u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcp100, Path.Combine(DllFullPath, "msvcp100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcr100, Path.Combine(DllFullPath, "msvcr100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_IPGBNETSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_IPGBNET, Path.Combine(DllFullPath, "IPGBNET.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_IPGBNETPush, Path.Combine(DllFullPath, "IPGBNETPush.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_IPGBNETSDK, Path.Combine(DllFullPath, "IPGBNETSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_CtlAudioDrv, Path.Combine(DllFullPath, "CtlAudioDrv.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_IPGBPushStream, Path.Combine(DllFullPath, "IPGBPushStream.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_lame_enc_dll, Path.Combine(DllFullPath, "lame_enc_dll.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libmp3lame, Path.Combine(DllFullPath, "libmp3lame.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfc100, Path.Combine(DllFullPath, "mfc100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfc100u, Path.Combine(DllFullPath, "mfc100u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcp100, Path.Combine(DllFullPath, "msvcp100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr100, Path.Combine(DllFullPath, "msvcr100.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_zlibwapi, Path.Combine(DllFullPath, "zlibwapi.dll"));
                }
            }
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBNETSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _IPGBNETSdk.Value; }
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return IPGBNETSdkDller.Instance;
        }
        /// <summary>
        /// 创建推流代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBPUSHSdkProxy CreatePush(bool isBase = false)
        {
            if (!isBase) { return _IPGBPUSHSdk.Value; }
            if (!File.Exists(IPGBPUSHSdk.BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(IPGBPUSHSdk.DllFullPath, IPGBPUSHSdk.BaseDllFullPath); }
            return IPGBPUSHSdkDller.Instance;
        }
        internal static TE[] SelectArray<TM, TE>(this TM[] tms, Func<TM, TE> GetElement)
        {
            if (tms == null || tms.Length == 0) { return new TE[0]; }
            var res = new List<TE>();
            foreach (var item in tms)
            {
                if (item == null) { continue; }
                res.Add(GetElement(item));
            }
            return res.ToArray();
        }
    }
}
