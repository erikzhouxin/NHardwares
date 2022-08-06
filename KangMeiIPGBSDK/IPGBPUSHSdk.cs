using System;
using System.Collections.Generic;
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
