using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.IO;
using System.IO.Compression;
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
            ms.Position = 0;
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
                stream.Position = 0;
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
        public static string FileGZipCompress(string sourceFilePath)
        {
            string zipFileName = sourceFilePath + ".gz";
            if (!File.Exists(sourceFilePath)) { return zipFileName; }
            using (FileStream zipFileStream = File.Create(zipFileName))
            {
                using (GZipStream zipStream = new GZipStream(zipFileStream, CompressionMode.Compress))
                {
                    using (FileStream sourceFileStream = File.OpenRead(sourceFilePath))
                    {
                        sourceFileStream.CopyTo(zipStream);
                    }
                }
            }
            return zipFileName;
        }
        /// <summary>
        /// 单文件解压缩（生成的压缩包和第三方的解压软件兼容）
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public static string FileGZipDecompress(string sourceFilePath, string savePath)
        {
            if (!File.Exists(sourceFilePath)) { return savePath; }
            using (FileStream sourceFileStream = File.OpenRead(sourceFilePath))
            {
                using (GZipStream zipStream = new GZipStream(sourceFileStream, CompressionMode.Decompress))
                {
                    using (FileStream zipFileStream = File.Create(savePath))
                    {
                        zipStream.CopyTo(zipFileStream);
                    }
                }
            }
            return savePath;
        }
        /// <summary>
        /// 自定义压缩SDK(不兼容解压工具)
        /// [名称长度4][名称][文件长度8][文件]
        /// </summary>
        /// <param name="map">文件压缩路径为Key,对应的物理路径为Value</param>
        /// <param name="savePath"></param>
        public static IAlertMsg FileGZipCompress(Dictionary<string, string> map, string savePath)
        {
            try
            {
                using (var zipFileStream = File.Create(savePath))
                {
                    using (var zipStream = new GZipStream(zipFileStream, CompressionMode.Compress))
                    {
                        foreach (var kv in map)
                        {
                            var filePath = kv.Value;
                            var fileName = kv.Key;
                            if (File.Exists(filePath))
                            {
                                byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(fileName);
                                byte[] sizeBytes = BitConverter.GetBytes(fileNameBytes.Length);
                                zipStream.Write(sizeBytes, 0, sizeBytes.Length);
                                zipStream.Write(fileNameBytes, 0, fileNameBytes.Length);
                                using (var fsRead = File.OpenRead(filePath))
                                {
                                    zipStream.Write(BitConverter.GetBytes(fsRead.Length), 0, 8);
                                    byte[] byts = new byte[1024];
                                    int len = 0;
                                    //4.通过读取文件流读取数据
                                    while ((len = fsRead.Read(byts, 0, byts.Length)) > 0)
                                    {
                                        //通过压缩流写入数据
                                        zipStream.Write(byts, 0, len);
                                    }
                                }
                            }
                            zipStream.Flush();
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
        /// 自定义解压SDK(不兼容解压工具)
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="tagDir"></param>
        /// <param name="Fillter"></param>
        public static IAlertMsg FileGZipDecompress(string zipFile, string tagDir, Func<string, bool> Fillter)
        {
            if (!File.Exists(zipFile)) { return AlertMsg.NotFound; }
            Fillter ??= (s) => true;
            try
            {
                using (FileStream fStream = File.Open(zipFile, FileMode.Open))
                {
                    using (GZipStream zipStream = new GZipStream(fStream, CompressionMode.Decompress))
                    {
                        while (zipStream.Position != zipStream.Length)
                        {
                            byte[] fileNameSize = new byte[4];
                            zipStream.Read(fileNameSize, 0, fileNameSize.Length);
                            int fileNameLength = BitConverter.ToInt32(fileNameSize, 0);
                            byte[] fileNameBytes = new byte[fileNameLength];
                            zipStream.Read(fileNameBytes, 0, fileNameBytes.Length);
                            string fileName = System.Text.Encoding.UTF8.GetString(fileNameBytes);
                            var fileSize = new byte[8];
                            zipStream.Read(fileSize, 0, 8);
                            var fileContentLength = BitConverter.ToInt64(fileSize, 0);
                            if (!Fillter.Invoke(fileName))
                            {
                                zipStream.Position += fileContentLength;
                                continue;
                            }
                            string fileFullName = System.IO.Path.Combine(tagDir, fileName);
                            var currDir = Path.GetDirectoryName(fileFullName);
                            if (!Directory.Exists(currDir)) { Directory.CreateDirectory(currDir); }
                            using (FileStream childFileStream = File.Create(fileFullName))
                            {
                                long readLen = 0;
                                while (readLen < fileContentLength)
                                {
                                    var takeLen = fileContentLength - readLen;
                                    if (takeLen > 1024) { takeLen = 1024; }
                                    readLen += takeLen;
                                    var content = new byte[takeLen];
                                    zipStream.Read(content, 0, content.Length);
                                    //通过文件流写入文件
                                    childFileStream.Write(content, 0, (int)takeLen);//读取的长度为len，这样不会造成数据的错误
                                }
                                childFileStream.Flush();
                            }
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
