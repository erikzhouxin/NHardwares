using System;
using System.Collections.Generic;
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
            Directory.CreateDirectory(IPGBNETSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(IPGBNETSdkLoader.DllFullName, Properties.Resources.X64_IPGBNETSDK);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_IPGBNETSDK, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBNETSDK.dll"));
                    WriteFile(Properties.Resources.X64_IPGBNETSDK1, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBNETSDK.lib"));
                    WriteFile(Properties.Resources.X64_CtlAudioDrv, Path.Combine(IPGBNETSdkLoader.DllFullPath, "CtlAudioDrv.dll"));
                    WriteFile(Properties.Resources.X64_IPGBPushStream, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBPushStream.dll"));
                    WriteFile(Properties.Resources.X64_IPGBPushStream1, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBPushStream.lib"));
                    WriteFile(Properties.Resources.X64_lame_enc_dll, Path.Combine(IPGBNETSdkLoader.DllFullPath, "lame_enc_dll.dll"));
                    WriteFile(Properties.Resources.X64_libmp3lame, Path.Combine(IPGBNETSdkLoader.DllFullPath, "libmp3lame.dll"));
                    WriteFile(Properties.Resources.X64_mfc100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "mfc100.dll"));
                    WriteFile(Properties.Resources.X64_mfc100u, Path.Combine(IPGBNETSdkLoader.DllFullPath, "mfc100u.dll"));
                    WriteFile(Properties.Resources.X64_msvcp100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "msvcp100.dll"));
                    WriteFile(Properties.Resources.X64_msvcr100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "msvcr100.dll"));
                    WriteFile(Properties.Resources.X64_zlibwapi, Path.Combine(IPGBNETSdkLoader.DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(IPGBNETSdkLoader.DllFullName, Properties.Resources.X86_IPGBNETSDK);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_IPGBNETSDK, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBNETSDK.dll"));
                    WriteFile(Properties.Resources.X86_IPGBNETSDK1, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBNETSDK.lib"));
                    WriteFile(Properties.Resources.X86_CtlAudioDrv, Path.Combine(IPGBNETSdkLoader.DllFullPath, "CtlAudioDrv.dll"));
                    WriteFile(Properties.Resources.X86_IPGBPushStream, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBPushStream.dll"));
                    WriteFile(Properties.Resources.X86_IPGBPushStream1, Path.Combine(IPGBNETSdkLoader.DllFullPath, "IPGBPushStream.lib"));
                    WriteFile(Properties.Resources.X86_lame_enc_dll, Path.Combine(IPGBNETSdkLoader.DllFullPath, "lame_enc_dll.dll"));
                    WriteFile(Properties.Resources.X86_libmp3lame, Path.Combine(IPGBNETSdkLoader.DllFullPath, "libmp3lame.dll"));
                    WriteFile(Properties.Resources.X86_mfc100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "mfc100.dll"));
                    WriteFile(Properties.Resources.X86_mfc100u, Path.Combine(IPGBNETSdkLoader.DllFullPath, "mfc100u.dll"));
                    WriteFile(Properties.Resources.X86_msvcp100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "msvcp100.dll"));
                    WriteFile(Properties.Resources.X86_msvcr100, Path.Combine(IPGBNETSdkLoader.DllFullPath, "msvcr100.dll"));
                    WriteFile(Properties.Resources.X86_zlibwapi, Path.Combine(IPGBNETSdkLoader.DllFullPath, "zlibwapi.dll"));
                }
            }
        }
        private static void WriteFile(byte[] dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        private static bool CompareFile(string file, byte[] res)
        {
            if (!File.Exists(file)) { return false; }
            using (var hash = SHA1.Create())
            {
                using (var distFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var resHash = hash.ComputeHash(res);
                    var distHash = hash.ComputeHash(distFile);
                    if (resHash.Length != distHash.Length) { return false; }
                    for (int i = 0; i < resHash.Length; i++)
                    {
                        if (resHash[i] != distHash[i]) { return false; }
                    }
                    return true;
                }
            }
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBNETSdkProxy Create(bool isBase)
        {
            var currentDir = IPGBNETSdkDller.DllFullPath;
            var pluginDir = IPGBNETSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(IPGBNETSdkDller.DllFullName))
                {
                    if (Directory.Exists(pluginDir))
                    {
                        try
                        {
                            CopyDirectory(pluginDir, currentDir);
                        }
                        catch { }
                    }
                }
                return IPGBNETSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return IPGBNETSdkDller.Instance; }
            return _IPGBNETSdk.Value;
        }
        /// <summary>
        /// 创建推流代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBPUSHSdkProxy CreatePush(bool isBase)
        {
            var currentDir = IPGBPUSHSdkDller.DllFullPath;
            var pluginDir = IPGBPUSHSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(IPGBPUSHSdkDller.DllFullName))
                {
                    if (Directory.Exists(pluginDir))
                    {
                        try
                        {
                            CopyDirectory(pluginDir, currentDir);
                        }
                        catch { }
                    }
                }
                return IPGBPUSHSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return IPGBPUSHSdkDller.Instance; }
            return _IPGBPUSHSdk.Value;
        }

        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tag"></param>
        public static void CopyDirectory(string src, string tag)
        {
            foreach (var item in new DirectoryInfo(src).GetFileSystemInfos())
            {
                if (item is DirectoryInfo dir)
                {
                    var tagDir = Path.Combine(tag, dir.Name);
                    if (!Directory.Exists(tagDir)) { Directory.CreateDirectory(tagDir); }
                    CopyDirectory(dir.FullName, tagDir);
                    continue;
                }
                File.Copy(item.FullName, Path.Combine(tag, item.Name), false);
            }
        }
        internal static TE[] SelectArray<TM, TE>(this TM[] tms, Func<TM, TE> GetElement)
        {
            if (tms == null || tms.Length == 0) { return new TE[0]; }
            var res = new List<TE>();
            foreach (var item in tms)
            {
                if(item == null) { continue; }
                res.Add(GetElement(item));
            }
            return res.ToArray();
        }
    }
}
