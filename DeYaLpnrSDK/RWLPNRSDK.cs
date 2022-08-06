﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.DeYaLpnrSDK
{
    /// <summary>
    /// 德亚道闸SDK
    /// </summary>
    public static class RWLPNRSdk
    {

        static Lazy<IRWLPNRSdkProxy> _RWLPNRSdk = new Lazy<IRWLPNRSdkProxy>(() => new RWLPNRSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static RWLPNRSdk()
        {
            Directory.CreateDirectory(RWLPNRSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(RWLPNRSdkLoader.DllFullName, Properties.Resources.X64_RWLPNRAPI);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_RWLPNRAPI, Path.Combine(RWLPNRSdkLoader.DllFullPath, "RWLPNRAPI.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(RWLPNRSdkLoader.DllFullName, Properties.Resources.X86_RWLPNRAPI);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_RWLPNRAPI, Path.Combine(RWLPNRSdkLoader.DllFullPath, "RWLPNRAPI.dll"));
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
        public static IRWLPNRSdkProxy Create(bool isBase = false)
        {
            var currentDir = RWLPNRSdkDller.DllFullPath;
            var pluginDir = RWLPNRSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(RWLPNRSdkDller.DllFullName))
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
                return RWLPNRSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return RWLPNRSdkDller.Instance; }
            return _RWLPNRSdk.Value;
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