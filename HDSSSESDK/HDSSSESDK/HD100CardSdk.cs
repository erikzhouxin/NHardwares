using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.HDSSSESDK
{
    /// <summary>
    /// SDK创建类
    /// </summary>
    public static class HD100CardSdk
    {
        static Lazy<IHD100CardSdkProxy> _hd100Card = new Lazy<IHD100CardSdkProxy>(() => new HD100CardSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static HD100CardSdk()
        {
            Directory.CreateDirectory(HD100CardSdkLoader.DllFullPath);
            bool isExists = CompareFile(HD100CardSdkLoader.DllFullName, Properties.Resources.X86_HDSSSE32);
            if (!isExists)
            {
                WriteFile(Properties.Resources.X86_HDSSSE32, Path.Combine(HD100CardSdkLoader.DllFullPath, "HDSSSE32.dll"));
                WriteFile(Properties.Resources.X86_UnPack, Path.Combine(HD100CardSdkLoader.DllFullPath, "UnPack.dll"));
                WriteFile(Properties.Resources.X86_BmpToJpg, Path.Combine(HD100CardSdkLoader.DllFullPath, "BmpToJpg.dll"));
            }
        }
        internal static void WriteFile(byte[] dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        internal static bool CompareFile(string file, byte[] res)
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
        /// 创建SDK代理,SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IHD100CardSdkProxy Create(bool isBase = false)
        {
            if (Environment.Is64BitProcess) // 此时不用其他方式就可以了
            {
                return HD100CardApi64.Instance;
            }
            var currentDir = HD100CardSdkDller.DllFullPath;
            var pluginDir = HD100CardSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(HD100CardSdkDller.DllFullName))
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
                return HD100CardSdkDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return HD100CardSdkDller.Instance; }
            return _hd100Card.Value;
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
        [Obsolete("替代方案:HD100CardSdk.Create")]
        internal static IHD100CardApi CreateApi()
        {
            if (Environment.Is64BitProcess) { return HD100CardApi64.Instance; }
            var currentDir = HD100CardSdkDller.DllFullPath;
            var pluginDir = HD100CardSdkLoader.DllFullPath;
            if (!File.Exists(HD100CardSdkDller.DllFullName))
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
            return new HD100CardApi();
        }
    }
}
