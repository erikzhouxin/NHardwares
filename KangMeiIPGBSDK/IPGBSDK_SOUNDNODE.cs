using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 声卡混音接口信息
     * typedef struct  
     * {
     *  char CapMixName[IPGB_MAX_SoundCardNAME];
     * }IPGBSDK_SOUNDNODE;
     **/
    public struct IPGBSDK_SOUNDNODE
    {
        /// <summary>
        /// 混合名称
        /// </summary>
        public string CapMixName;
    }
    /// <summary>
    /// 声卡混音接口信息
    /// </summary>
    public class NETAVHSDK_SOUNDNODE
    {
        /// <summary>
        /// 混合名称
        /// </summary>
        public string CapMixName;
    }
}
