using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Text;

namespace System.Data.EDBODBCSDK
{
    /// <summary>
    /// 数据访问SDK
    /// </summary>
    public static class DbAccessSdk
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\edbodbcsdk";
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

        static Lazy<IDbAccessSdkProxy> _dbAccess = new Lazy<IDbAccessSdkProxy>(() => new DbAccessSdkApi(), true);
        static DbAccessSdk()
        {
            var res = new SdkFileLoaderModel()
            {
                BasePath = DllFullPath,
                PlatformPath = Environment.Is64BitProcess ? "x64" : "x86",
                VersionFile = $"{nameof(EDBODBCSDK)}.version",
                SdkFileName = DllSdkFile
            }.Build();
            if (res.IsSuccess) { return; }
            throw new Exception(res.Message, (res as IAlertException)?.Exception);
        }
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IDbAccessSdkProxy Instance { get => Environment.Is64BitProcess ? DbAccessSdkApi64.Instance : _dbAccess.Value; }
        /// <summary>
        /// 创建SDK代理,SDK原生不支持64位,所以64位可能有性能损耗
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IDbAccessSdkProxy Create(bool isBase = false)
        {
            if (Environment.Is64BitProcess) { return DbAccessSdkApi64.Instance; }
            return isBase ? new DbAccessSdkApi() : _dbAccess.Value;
        }
    }
}
