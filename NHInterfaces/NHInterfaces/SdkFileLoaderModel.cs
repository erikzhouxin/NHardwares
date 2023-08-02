using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Extter;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace System.Data.NHInterfaces
{
    /// <summary>
    /// SDK文件加载模型
    /// </summary>
    public class SdkFileLoaderModel
    {
        /// <summary>
        /// SDK基础路径
        /// </summary>
        public string BasePath { get; set; }
        /// <summary>
        /// SDK平台路径(相对[BasePath]的路径)
        /// </summary>
        public string PlatformPath { get; set; }
        /// <summary>
        /// 文件版本校验文件
        /// </summary>
        public string VersionFile { get; set; }
        /// <summary>
        /// SDK文件名称(完整路径)
        /// </summary>
        public string SdkFileName { get; set; }
        /// <summary>
        /// 创建SDK内容
        /// </summary>
        public IAlertMsg Build()
        {
            return TestTry.Try(() =>
            {
                var sdkFileName = Path.GetFullPath(SdkFileName);
                if (!File.Exists(sdkFileName)) { return AlertMsg.NotFound; }
                var basePath = Path.GetFullPath(BasePath);
                var platformTag = PlatformPath;
                var platformPath = Path.GetFullPath(Path.Combine(basePath, PlatformPath));
                var versionPath = Path.GetFullPath(Path.Combine(platformPath, VersionFile));
                string versionContent = string.Empty;
                using (var stream = new FileStream(sdkFileName, FileMode.Open, FileAccess.Read))
                {
                    versionContent = SHA512.Create().ComputeHash(stream).GetHexString(true);
                }
                if (File.Exists(versionPath))
                {
                    var versionId = File.ReadAllText(versionPath);
                    if (versionId == versionContent) { return AlertMsg.OperSuccess; }
                }
                if (Directory.Exists(platformPath)) { Directory.Delete(platformPath, true); }
                Directory.CreateDirectory(platformPath);
                var result = ExtterCaller.FileGZipDecompress(sdkFileName, basePath, f => f.StartsWith(platformTag));
                File.WriteAllText(versionPath, versionContent);
                return result;
            }, (ex) => new AlertException(ex));
        }
    }
}
