using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
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
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "RWLPNRAPI.dll";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllVirtualPath = @"plugins\deyalpnrsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);

        static Lazy<IRWLPNRSdkProxy> _RWLPNRSdk = new Lazy<IRWLPNRSdkProxy>(() => new RWLPNRSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static RWLPNRSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_RWLPNRAPI))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_RWLPNRAPI, Path.Combine(DllFullPath, "RWLPNRAPI.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_RWLPNRAPI))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_RWLPNRAPI, Path.Combine(DllFullPath, "RWLPNRAPI.dll"));
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
            if (!isBase) { return _RWLPNRSdk.Value; }
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return RWLPNRSdkDller.Instance;
            ;
        }
    }
}
