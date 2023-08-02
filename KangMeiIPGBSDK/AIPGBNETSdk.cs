using NAudio.MediaFoundation;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
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
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\kangmeiipgbsdk";
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
        /// 全路径
        /// </summary>
        public static string BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        #region // 参数定义
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
        #endregion 参数定义
        static Lazy<IIPGBNETSdkProxy> _IPGBNETSdk = new Lazy<IIPGBNETSdkProxy>(() => new IPGBNETSdkLoader(), true);
        static Lazy<IIPGBPUSHSdkProxy> _IPGBPUSHSdk = new Lazy<IIPGBPUSHSdkProxy>(() => new IPGBPUSHSdkLoader(), true);
        static IPGBNETSdk()
        {
            MediaFoundationApi.Startup();
            var res = new SdkFileLoaderModel()
            {
                BasePath = DllFullPath,
                PlatformPath = Environment.Is64BitProcess ? "x64" : "x86",
                VersionFile = $"{nameof(KangMeiIPGBSDK)}.version",
                SdkFileName = DllSdkFile
            }.Build();
            if (res.IsSuccess) { return; }
            throw new Exception(res.Message, (res as IAlertException)?.Exception);
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBNETSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _IPGBNETSdk.Value; }
            return Environment.Is64BitProcess ? IPGBNETSdkDllerX64.Instance : IPGBNETSdkDllerX86.Instance;
        }
        /// <summary>
        /// 创建推流代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBPUSHSdkProxy CreatePush(bool isBase = false)
        {
            if (!isBase) { return _IPGBPUSHSdk.Value; }
            return Environment.Is64BitProcess ? IPGBPUSHSdkDllerX64.Instance : IPGBPUSHSdkDllerX86.Instance;
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
        /// <summary>
        /// 转换成Mp3格式
        /// </summary>
        /// <param name="memory"></param>
        /// <param name="fileName"></param>
        public static void ConvertToMp3(Stream memory, string fileName)
        {
            using (var reader = new WaveFileReader(memory))
            {
                // MediaFoundationEncoder.EncodeToMp3(reader, filePath, 128000);
                var mediaType = MediaFoundationEncoder.SelectMediaType(AudioSubtypes.MFAudioFormat_MP3, new WaveFormat(44100, 2), 128000);
                using (var mediaEncoder = new MediaFoundationEncoder(mediaType))
                {
                    mediaEncoder.Encode(fileName, reader);
                }
            }
        }
    }
}
