using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// SDK调用
    /// </summary>
    public static class IceIpcSdk
    {
        static Lazy<IIceIpcSdkProxy> _iceIpcSdk = new Lazy<IIceIpcSdkProxy>(() => new IceIpcSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static IceIpcSdk()
        {
            Directory.CreateDirectory(IceIpcSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(IceIpcSdkLoader.DllFullName, Properties.Resources.X64_IceIpcSdk);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_IceIpcSdk, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_ipcsdk.dll"));
                    WriteFile(Properties.Resources.X64_Avutil52, Path.Combine(IceIpcSdkLoader.DllFullPath, "avutil-52.dll"));
                    WriteFile(Properties.Resources.X64_Draw, Path.Combine(IceIpcSdkLoader.DllFullPath, "draw.dll"));
                    WriteFile(Properties.Resources.X64_HiH264decW64, Path.Combine(IceIpcSdkLoader.DllFullPath, "hi_h264dec_w64.dll"));
                    WriteFile(Properties.Resources.X64_IceP2p, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_p2p.dll"));
                    WriteFile(Properties.Resources.X64_Packet, Path.Combine(IceIpcSdkLoader.DllFullPath, "Packet.dll"));
                    WriteFile(Properties.Resources.X64_Swscale2, Path.Combine(IceIpcSdkLoader.DllFullPath, "swscale-2.dll"));
                    WriteFile(Properties.Resources.X64_Wpcap, Path.Combine(IceIpcSdkLoader.DllFullPath, "wpcap.dll"));
                    WriteFile(Properties.Resources.X64_Zlibwapi, Path.Combine(IceIpcSdkLoader.DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(IceIpcSdkLoader.DllFullName, Properties.Resources.X86_IceIpcSdk);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_IceIpcSdk, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_ipcsdk.dll"));
                    WriteFile(Properties.Resources.X86_Avutil52, Path.Combine(IceIpcSdkLoader.DllFullPath, "avutil-52.dll"));
                    WriteFile(Properties.Resources.X86_Draw, Path.Combine(IceIpcSdkLoader.DllFullPath, "draw.dll"));
                    WriteFile(Properties.Resources.X86_HiH264decW, Path.Combine(IceIpcSdkLoader.DllFullPath, "hi_h264dec_w.dll"));
                    WriteFile(Properties.Resources.X86_IceP2p, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_p2p.dll"));
                    WriteFile(Properties.Resources.X86_Packet, Path.Combine(IceIpcSdkLoader.DllFullPath, "Packet.dll"));
                    WriteFile(Properties.Resources.X86_Swscale2, Path.Combine(IceIpcSdkLoader.DllFullPath, "swscale-2.dll"));
                    WriteFile(Properties.Resources.X86_Wpcap, Path.Combine(IceIpcSdkLoader.DllFullPath, "wpcap.dll"));
                    WriteFile(Properties.Resources.X86_Zlibwapi, Path.Combine(IceIpcSdkLoader.DllFullPath, "zlibwapi.dll"));
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
        public static IIceIpcSdkProxy Create(bool isBase = false)
        {
            var currentDir = IceIpcDller.DllFullPath;
            var pluginDir = IceIpcSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(IceIpcDller.DllFullName))
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
                return IceIpcDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return IceIpcDller.Instance; }
            return _iceIpcSdk.Value;
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
    }
}
