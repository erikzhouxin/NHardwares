using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 单个终端信息
	 * typedef struct  
	 * {
	 *   char     TmName[IPGB_MAX_TMNAME_LEN];//终端名
	 *   char     Tmip[IPGB_MAX_IPADR_LEN];   //终端IP
	 *   EM_TMSTA_TYPE TmSta;                 //终端当前工作状态 
	 *   WORD     TmNo;                       //终端机号 
	 *   BYTE     TmVol;                      //终端音量
	 *   BYTE     ISOnLine;                   //终端是否在线 1:在线;0:离线 
	 *   WORD     GbStreamid;                 //当工作状态为TMSTA_STA3或TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
	 *                                        //用于区分服务器其它创建的广播
	 *   WORD     OtherTalkTmId;              //如终端在对讲，此处为对方终端ID
	 * }IPGBSDK_TMINFO,*LPIPGBSDK_TMINFO;
	 **/
    public struct IPGBSDK_TMINFO
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
        /// 终端音量
        /// </summary>
        public byte TmVol;
        /// <summary>
        /// 终端是否在线 1:在线;0:离线
        /// </summary>
        public byte ISOnLine;
        /// <summary>
        /// 当工作状态为TMSTA_STA3或TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
        /// 用于区分服务器其它创建的广播
        /// </summary>
        public ushort GbStreamid;
        /// <summary>
        /// 如终端在对讲，此处为对方终端ID
        /// </summary>
        public uint OtherTalkTmId;
    }
    /// <summary>
    /// 单个终端信息
    /// </summary>
    public class NETAVHSDK_TMINFO
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
        /// 终端音量
        /// </summary>
        public byte TmVol;
        /// <summary>
        /// 终端是否在线 1:在线;0:离线
        /// </summary>
        public byte ISOnLine;
        /// <summary>
        /// 当工作状态为TMSTA_STA3或TMSTA_STA4时，GbStreamid>0为本SDK控制的广播
        /// 用于区分服务器其它创建的广播
        /// </summary>
        public ushort GbStreamid;
        /// <summary>
        /// 如终端在对讲，此处为对方终端ID
        /// </summary>
        public uint OtherTalkTmId;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator IPGBSDK_TMINFO(NETAVHSDK_TMINFO info)
        {
            return new IPGBSDK_TMINFO
            {
                GbStreamid = info.GbStreamid,
                ISOnLine = info.ISOnLine,
                OtherTalkTmId = info.OtherTalkTmId,
                Tmip = info.Tmip,
                TmName = info.TmName,
                TmSta = info.TmSta,
                TmNo = info.TmNo,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator NETAVHSDK_TMINFO(IPGBSDK_TMINFO info)
        {
            return new NETAVHSDK_TMINFO
            {
                TmName = info.TmName,
                GbStreamid = info.GbStreamid,
                Tmip = info.Tmip,
                OtherTalkTmId = info.OtherTalkTmId,
                ISOnLine = info.ISOnLine,
                TmNo = info.TmNo,
                TmSta = info.TmSta,
                TmVol = info.TmVol,
            };
        }
    }
}
