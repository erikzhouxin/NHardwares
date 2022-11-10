using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 推流SDK
    /// </summary>
    public static class IPGBPUSHSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const String DllFileName = "IPGBPushStream.dll";
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
        public const string DllVirtualPath = @"plugins\kangmeiipgbsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        /// <summary>
        /// 声卡名称
        /// </summary>
        public const int IPGBPUSH_MAX_SoundCardNAME = 512;
        /// <summary>
        /// IP长度
        /// </summary>
        public const int IPGBPUSH_MAX_IPLEN = 30;
        /// <summary>
        /// 域名长度
        /// </summary>
        public const int IPGBPUSH_MAX_DOMAINLEN = 128;
        /// <summary>
        /// 认证长度
        /// </summary>
        public const int IPGBPUSH_MAX_DESLEN = 8;
        /// <summary>
        /// 混合计数
        /// </summary>
        public const int IPGBPUSH_MAX_SysSoundCardMixCout = 20;
        /// <summary>
        /// 本地文件路径长度
        /// </summary>
        public const int IPGBPUSH_MAX_LCAFILEPATHLEN = 256;
        /// <summary>
        /// 本地文件计数
        /// </summary>
        public const int IPGBPUSH_MAX_LCAFILECOUT = 60;
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIPGBPUSHSdkProxy Create(bool isBase = false) => IPGBNETSdk.CreatePush(isBase);
    }
}
