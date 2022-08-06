using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 简单微光条码SDK调用
    /// </summary>
    public static class SimpleVBarSdk
    {
        static Lazy<ISimpleVBarSdkProxy> _RWLPNRSdk = new Lazy<ISimpleVBarSdkProxy>(() => new SimpleVBarSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static SimpleVBarSdk()
        {
            Directory.CreateDirectory(SimpleVBarSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(SimpleVBarSdkLoader.DllFullName, Properties.Resources.X64_vbar);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_vbar, Path.Combine(SimpleVBarSdkLoader.DllFullPath, "vbar.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(SimpleVBarSdkLoader.DllFullName, Properties.Resources.X86_vbar);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_vbar, Path.Combine(SimpleVBarSdkLoader.DllFullPath, "vbar.dll"));
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
        public static ISimpleVBarSdkProxy Create(bool isBase = false)
        {
            var currentDir = SimpleVBarSdkDller.DllFullPath;
            var pluginDir = SimpleVBarSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(SimpleVBarSdkDller.DllFullName))
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
                return SimpleVBarSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return SimpleVBarSdkDller.Instance; }
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
