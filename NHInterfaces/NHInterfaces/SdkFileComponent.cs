using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.SharpZipLib;
using System.IO;
using System.IO.Compression;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
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
                if (!Directory.Exists(Path.GetDirectoryName(fullName))) { Directory.CreateDirectory(Path.GetDirectoryName(fullName)); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        /// <summary>
        /// 写资源文件
        /// </summary>
        /// <param name="dllFile"></param>
        /// <param name="fullName"></param>
        public static void WriteResourceFile(Stream dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                if (!Directory.Exists(Path.GetDirectoryName(fullName))) { Directory.CreateDirectory(Path.GetDirectoryName(fullName)); }
                using (var fs = File.Create(fullName))
                {
                    dllFile.Seek(0, SeekOrigin.Begin);
                    dllFile.CopyTo(fs);
                    fs.Flush();
                }
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
        /// 比较资源文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool CompareResourceFile(string file, Stream res)
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
        /// <summary>
        /// 获取一个资源字节
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte[] GetResourceBytes(Assembly assembly, string name)
        {
            var res = assembly.GetManifestResourceNames().WhereSelect(s => s.EndsWith(name), s => s);
            var count = res.Count();
            if (count == 0) { throw new ArgumentNullException($"未找到'{name}'的资源文件"); }
            if (count != 1) { throw new ArgumentOutOfRangeException($"找到不唯一的'{name}'的资源文件"); }
            using (var ms = new MemoryStream())
            {
                assembly.GetManifestResourceStream(res.First()).CopyTo(ms);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 获取一个资源流
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Stream GetResourceStream(Assembly assembly, string name)
        {
            var res = assembly.GetManifestResourceNames().WhereSelect(s => s.EndsWith(name), s => s);
            var count = res.Count();
            if (count == 0) { throw new ArgumentNullException($"未找到'{name}'的资源文件"); }
            if (count != 1) { throw new ArgumentOutOfRangeException($"找到不唯一的'{name}'的资源文件"); }
            var ms = new MemoryStream();
            assembly.GetManifestResourceStream(res.First()).CopyTo(ms);
            //ms.Position = 0;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
        /// <summary>
        /// 获取一个资源文件
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static FileInfo GetResource(Assembly assembly, string name)
        {
            return GetResource(assembly, name, Directory.GetCurrentDirectory());
        }
        /// <summary>
        /// 获取一个资源文件
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static FileInfo GetResource(Assembly assembly, string name, string savePath)
        {
            var res = assembly.GetManifestResourceNames().WhereSelect(s => s.EndsWith(name), s => s);
            var count = res.Count();
            if (count == 0) { throw new ArgumentNullException($"未找到'{name}'的资源文件"); }
            if (count != 1) { throw new ArgumentOutOfRangeException($"找到不唯一的'{name}'的资源文件"); }
            var stream = assembly.GetManifestResourceStream(res.First());
            string fileFullName;
            if (Directory.Exists(savePath))
            {
                string fileName;
                using (var sha1 = SHA1.Create())
                {
                    var hash = sha1.ComputeHash(stream);
                    fileName = hash.GetSha1HexString(true);
                }
                fileFullName = Path.Combine(savePath, fileName);
            }
            else { fileFullName = savePath; }
            using (var fs = File.Create(fileFullName))
            {
                //stream.Position = 0;
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fs);
                fs.Flush();
            }
            return new FileInfo(fileFullName);
        }

        #region // 文件自定义
        /// <summary>
        /// 单文件压缩（生成的压缩包和第三方的解压软件兼容）
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <returns></returns>
        public static string FileGZipCompress(string sourceFilePath) => ExtterCaller.FileGZipCompress(sourceFilePath);
        /// <summary>
        /// 单文件解压缩（生成的压缩包和第三方的解压软件兼容）
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public static string FileGZipDecompress(string sourceFilePath, string savePath) => ExtterCaller.FileGZipDecompress(sourceFilePath, savePath);
        /// <summary>
        /// 自定义压缩SDK(不兼容解压工具)
        /// [名称长度4][名称][文件长度8][文件]
        /// </summary>
        /// <param name="map">文件压缩路径为Key,对应的物理路径为Value</param>
        /// <param name="savePath"></param>
        public static IAlertMsg FileGZipCompress(Dictionary<string, string> map, string savePath) => ExtterCaller.FileGZipCompress(map, savePath);
        /// <summary>
        /// 自定义解压SDK(不兼容解压工具)
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="tagDir"></param>
        /// <param name="Fillter"></param>
        public static IAlertMsg FileGZipDecompress(string zipFile, string tagDir, Func<string, bool> Fillter) => ExtterCaller.FileGZipDecompress(zipFile, tagDir, Fillter);
        /// <summary>
        /// 自定义压缩SDK
        /// </summary>
        /// <param name="map">文件压缩路径为Key,对应的物理路径为Value</param>
        /// <param name="savePath"></param>
        public static void FileGZipCompressSDK(Dictionary<string, string> map, string savePath) => FileGZipCompress(map, savePath);
        /// <summary>
        /// 自定义解压SDK
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="tagDir"></param>
        /// <param name="isX86"></param>
        public static void FileGZipDecompressSDK(string zipFile, string tagDir, bool? isX86 = null)
            => FileGZipDecompress(zipFile, tagDir, f => IsPlatformTargetPath(f, isX86));
        /// <summary>
        /// Zip压缩文件
        /// </summary>
        /// <param name="map">文件压缩路径为Key,对应的物理路径为Value</param>
        /// <param name="savePath"></param>
        public static IAlertMsg FileZipCompress(Dictionary<string, string> map, string savePath)
        {
            try
            {
                using (var outStream = new ZipOutputStream(File.Create(savePath)))
                {
                    outStream.SetLevel(-1);
                    byte[] buffer = new byte[4096];
                    foreach (var kv in map)
                    {
                        var filePath = kv.Value;
                        var fileName = kv.Key;
                        if (File.Exists(filePath))
                        {
                            var entry = new ZipEntry(fileName);
                            outStream.PutNextEntry(entry);
                            using (var inStream = File.OpenRead(filePath))
                            {
                                int sizeRead = 0;
                                do
                                {
                                    // 从流中读取字节，将该数据写入缓冲区
                                    sizeRead = inStream.Read(buffer, 0, buffer.Length);
                                    outStream.Write(buffer, 0, sizeRead);

                                } while (sizeRead > 0);
                            }
                        }
                    }
                }
                return (AlertMsg<string>)(true, "操作成功", savePath);
            }
            catch (Exception ex)
            {
                return new AlertException(ex);
            }
        }
        /// <summary>
        /// zip解压缩并过滤
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="tagDir"></param>
        /// <param name="Fillter"></param>
        public static IAlertMsg FileZipDecompress(string zipFile, string tagDir, Func<string, bool> Fillter = null)
        {
            if (!File.Exists(zipFile)) { return AlertMsg.NotFound; }
            Fillter ??= (s) => true;
            try
            {
                using (var inStream = new ZipInputStream(File.OpenRead(zipFile)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = inStream.GetNextEntry()) != null)
                    {
                        string fileName = Path.GetFullPath(Path.Combine(tagDir, theEntry.Name));
                        var dir = Path.GetDirectoryName(fileName);
                        if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                        if (Path.GetFileName(theEntry.Name) == "") { continue; }
                        using (var fs = File.Create(fileName))
                        {
                            byte[] data = new byte[4096];
                            int size;
                            do
                            {
                                size = inStream.Read(data, 0, data.Length);
                                fs.Write(data, 0, size);
                            } while (size > 0);
                            fs.Flush();
                        }
                    }
                }
                return (AlertMsg<String>)(true, "操作成功", tagDir);
            }
            catch (Exception ex)
            {
                return new AlertException(ex);
            }
        }
        /// <summary>
        /// 是平台标记开头的路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isX86"></param>
        /// <returns></returns>
        public static bool IsPlatformTargetPath(string fileName, bool? isX86)
        {
            if (!isX86.HasValue) { return true; }
            return isX86.Value
                ? fileName.StartsWith("x86", StringComparison.OrdinalIgnoreCase)
                : fileName.StartsWith("x64", StringComparison.OrdinalIgnoreCase);
        }
        #endregion 文件自定义
    }
}
