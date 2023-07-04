using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ZycooSIPNetSDK
{
    /// <summary>
    /// 智科通信SIP网络电话SDK
    /// </summary>
    public static partial class ZycooSIPNetSdk
    {
        /// <summary>
        /// 创建代理
        /// </summary>
        /// <returns></returns>
        public static IZycooSIPNetApiProxyV1 Create()
        {
            return new ZycooSIPNetApiProxyV1();
        }
        /// <summary>
        /// 创建代理
        /// </summary>
        /// <returns></returns>
        public static IZycooSIPNetApiProxyV1 Create(this ZycooConfigModelV1 config)
        {
            return new ZycooSIPNetApiProxyV1(config);
        }
    }
}
