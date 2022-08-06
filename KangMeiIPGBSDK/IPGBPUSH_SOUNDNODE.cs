using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 声卡混音接口信息
    /// typedef struct  
    /// {
    ///  char CapMixName[IPGBPUSH_MAX_SoundCardNAME];
    /// }IPGBPUSH_SOUNDNODE;
    /// </summary>
    public struct IPGBPUSH_SOUNDNODE
    {
        /// <summary>
        /// 声卡混合名称
        /// </summary>
        public string CapMixName;
    }
    /// <summary>
    /// 声卡混音接口信息
    /// </summary>
    public class NETPUSHSDK_SOUNDNODE
    {
        /// <summary>
        /// 声卡混合名称
        /// </summary>
        public string CapMixName;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_SOUNDNODE(IPGBPUSH_SOUNDNODE model)
        {
            return new NETPUSHSDK_SOUNDNODE()
            {
                CapMixName = model.CapMixName,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_SOUNDNODE(NETPUSHSDK_SOUNDNODE model)
        {
            return new IPGBPUSH_SOUNDNODE()
            {
                CapMixName = model.CapMixName,
            };
        }
    }
}
