using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * typedef struct  
     * {
     *   WORD CapMixCout;                             //系统默认声卡混音接口个数
     *   IPGBSDK_SOUNDNODE SOUNDNODES[IPGB_MAX_SoundCardMixCout];//系统默认声卡混音接口名数组
     * }IPGBSDK_SOUNDCARDINFO,*LPIPGBSDK_SOUNDCARDINFO;
     **/
    public struct IPGBSDK_SOUNDCARDINFO
    {
        /// <summary>
        /// 系统默认声卡混音接口个数
        /// </summary>
        public ushort CapMixCout;
        /// <summary>
        /// 系统默认声卡混音接口名数组
        /// </summary>
        public IPGBSDK_SOUNDNODE[] SOUNDNODES;
    }
    /// <summary>
    /// 声卡信息
    /// </summary>
    public class NETAVHSDK_SOUNDCARDINFO
    {
        /// <summary>
        /// 系统默认声卡混音接口个数
        /// </summary>
        public ushort CapMixCout;
        /// <summary>
        /// 系统默认声卡混音接口名数组
        /// </summary>
        public NETAVHSDK_SOUNDNODE[] SOUNDNODES;
    }
}
