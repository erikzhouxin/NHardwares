using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.NHInterfaces
{
    /// <summary>
    /// SDK文件组件
    /// </summary>
    public static class SdkFileComponent
    {
        /// <summary>
        /// 写资源文件
        /// </summary>
        /// <param name="dllFile"></param>
        /// <param name="fullName"></param>
        public static void WriteResourceFile(byte[] dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        /// <summary>
        /// 比较资源文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool CompareResourceFile(string file, byte[] res)
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
        /// <summary>
        /// 尝试复制文件夹
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tag"></param>
        public static void TryCopyDirectory(string src, string tag)
        {
            try
            {
                CopyDirectory(src, tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(new { src, tag, method = nameof(TryCopyDirectory), ex });
            }
        }
    }
}
