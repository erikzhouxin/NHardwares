using System;
using System.Linq;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 批量终端状态更新回调信息
	 * typedef struct  
	 * {
	 *   WORD  TmCout;//更新的终端个数
	 *   IPGBSDK_TMINFO *m_oneTm[IPGB_MAX_SDKTMCOUT];//更新的终端数组指针
	 * }IPGBSDK_CALLBACKTMINFO,*LPIPGBSDK_CALLBACKTMINFO;
	 **/
    public struct IPGBSDK_CALLBACKTMINFO
    {
        /// <summary>
        /// 更新的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 更新的终端数组指针
        /// </summary>
        public IPGBSDK_TMINFO[] m_oneTm;
    }
    /// <summary>
    /// 批量终端状态更新回调信息
    /// </summary>
    public class NETAVHSDK_CALLBACKTMINFO
    {
        /// <summary>
        /// 更新的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 更新的终端数组指针
        /// </summary>
        public NETAVHSDK_TMINFO[] m_oneTm;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator NETAVHSDK_CALLBACKTMINFO(IPGBSDK_CALLBACKTMINFO info)
        {
            return new NETAVHSDK_CALLBACKTMINFO()
            {
                TmCout = info.TmCout,
                m_oneTm = info.m_oneTm.SelectArray(s => (NETAVHSDK_TMINFO)s)
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator IPGBSDK_CALLBACKTMINFO(NETAVHSDK_CALLBACKTMINFO info)
        {
            return new IPGBSDK_CALLBACKTMINFO()
            {
                TmCout = info.TmCout,
                m_oneTm = info.m_oneTm.SelectArray(s => (IPGBSDK_TMINFO)s)
            };
        }
    }
}
