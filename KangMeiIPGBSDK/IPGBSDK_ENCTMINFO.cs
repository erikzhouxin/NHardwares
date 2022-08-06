using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 单个编码终端信息
	 * typedef struct  
	 * {
	 *   char     TmName[IPGB_MAX_TMNAME_LEN];//终端名
	 *   char     Tmip[IPGB_MAX_IPADR_LEN];   //终端IP
	 *   EM_TMSTA_TYPE TmSta;                 //终端当前工作状态 
	 *   WORD     TmNo;                       //终端机号 
	 *   WORD     GbStreamid;                 //当工作状态为TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
	 *                                        //用于区分服务器其它创建的广播
	 *   BYTE     ISOnLine;                   //终端是否在线 1:在线;0:离线 
	 *   }IPGBSDK_ENCTMINFO,*LPIPGBSDK_ENCTMINFO;
	 **/
    public struct IPGBSDK_ENCTMINFO
    {
        /// <summary>
        /// 终端名
        /// </summary>
        public string TmName;
        /// <summary>
        /// 终端IP
        /// </summary>
        public string Tmip;
        /// <summary>
        /// 终端当前工作状态
        /// </summary>
        public NETEM_TMSTA_TYPE TmSta;
        /// <summary>
        /// 终端机号
        /// </summary>
        public uint TmNo;
        /// <summary>
        /// 当工作状态为TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
        /// 用于区分服务器其它创建的广播
        /// </summary>
        public ushort GbStreamid;
        /// <summary>
        /// 终端是否在线 1:在线;0:离线
        /// </summary>
        public byte ISOnLine;
    }
    /// <summary>
    /// 单个编码终端信息
    /// </summary>
    public class NETAVHSDK_ENCTMINFO
    {
        /// <summary>
        /// 终端名
        /// </summary>
        public string TmName;
        /// <summary>
        /// 终端IP
        /// </summary>
        public string Tmip;
        /// <summary>
        /// 终端当前工作状态
        /// </summary>
        public NETEM_TMSTA_TYPE TmSta;
        /// <summary>
        /// 终端机号
        /// </summary>
        public uint TmNo;
        /// <summary>
        /// 当工作状态为TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
        /// 用于区分服务器其它创建的广播
        /// </summary>
        public ushort GbStreamid;
        /// <summary>
        /// 终端是否在线 1:在线;0:离线
        /// </summary>
        public byte ISOnLine;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator IPGBSDK_ENCTMINFO(NETAVHSDK_ENCTMINFO info)
        {
            return new IPGBSDK_ENCTMINFO
            {
                TmSta = info.TmSta,
                TmNo = info.TmNo,
                GbStreamid = info.GbStreamid,
                ISOnLine = info.ISOnLine,
                Tmip = info.Tmip,
                TmName = info.TmName,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator NETAVHSDK_ENCTMINFO(IPGBSDK_ENCTMINFO info)
        {
            return new NETAVHSDK_ENCTMINFO
            {
                TmSta = info.TmSta,
                TmNo = info.TmNo,
                GbStreamid = info.GbStreamid,
                ISOnLine = info.ISOnLine,
                Tmip = info.Tmip,
                TmName = info.TmName,
            };
        }
    }
}
