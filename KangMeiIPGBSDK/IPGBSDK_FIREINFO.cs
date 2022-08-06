using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 消防信号回调信息
	 * typedef struct  
	 * {
	 *   unsigned int  Fno;//此消防信号所在32路消防采集终端机号(1-32) Fno=1 表示1-32信号,Fno=2 表示33-64信号,依次类推
	 *   unsigned int  FVal;//32路信号状态(从字的低位为第一路信号),位为1表示有信号，位0无信号
	 * }IPGBSDK_FIREINFO,*LPIPGBSDK_FIREINFO;
	 **/
    public struct IPGBSDK_FIREINFO
    {
        /// <summary>
        /// 此消防信号所在32路消防采集终端机号(1-32) Fno=1 表示1-32信号,Fno=2 表示33-64信号,依次类推
        /// </summary>
        public ushort Fno;
        /// <summary>
        /// 32路信号状态(从字的低位为第一路信号),位为1表示有信号，位0无信号
        /// </summary>
        public ushort FVal;
    }
    /// <summary>
    /// 消防信号回调信息
    /// </summary>
    public class NETAVHSDK_FIREINFO
    {
        /// <summary>
        /// 此消防信号所在32路消防采集终端机号(1-32) Fno=1 表示1-32信号,Fno=2 表示33-64信号,依次类推
        /// </summary>
        public ushort Fno;
        /// <summary>
        /// 32路信号状态(从字的低位为第一路信号),位为1表示有信号，位0无信号
        /// </summary>
        public ushort FVal;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator NETAVHSDK_FIREINFO(IPGBSDK_FIREINFO info)
        {
            return new NETAVHSDK_FIREINFO
            {
                Fno = info.Fno,
                FVal = info.FVal,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator IPGBSDK_FIREINFO(NETAVHSDK_FIREINFO info)
        {
            return new IPGBSDK_FIREINFO
            {
                Fno = info.Fno,
                FVal = info.FVal,
            };
        }
    }
}
