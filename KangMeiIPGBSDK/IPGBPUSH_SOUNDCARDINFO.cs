using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// typedef struct  
    /// {
    ///   WORD CapMixCout;                             //系统默认声卡混音接口个数
    ///   IPGBPUSH_SOUNDNODE SOUNDNODES[IPGBPUSH_MAX_SysSoundCardMixCout];//系统默认声卡混音接口名数组
    /// }IPGBPUSH_SOUNDCARDINFO,*LPIPGBPUSH_SOUNDCARDINFO;
    /// </summary>
    public struct IPGBPUSH_SOUNDCARDINFO
    {
        /// <summary>
        /// 系统默认声卡混音接口个数
        /// </summary>
        public ushort CapMixCout;
        /// <summary>
        /// 系统默认声卡混音接口名数组
        /// </summary>
        public IPGBPUSH_SOUNDNODE[] SOUNDNODES;
    }
    /// <summary>
    /// 声卡信息
    /// </summary>
    public class NETPUSHSDK_SOUNDCARDINFO
    {
        /// <summary>
        /// 系统默认声卡混音接口个数
        /// </summary>
        public ushort CapMixCout;
        /// <summary>
        /// 系统默认声卡混音接口名数组
        /// </summary>
        public NETPUSHSDK_SOUNDNODE[] SOUNDNODES;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_SOUNDCARDINFO(IPGBPUSH_SOUNDCARDINFO model)
        {
            return new NETPUSHSDK_SOUNDCARDINFO()
            {
                CapMixCout = model.CapMixCout,
                SOUNDNODES = model.SOUNDNODES.SelectArray(s => (NETPUSHSDK_SOUNDNODE)s)
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_SOUNDCARDINFO(NETPUSHSDK_SOUNDCARDINFO model)
        {
            return new IPGBPUSH_SOUNDCARDINFO()
            {
                CapMixCout = model.CapMixCout,
                SOUNDNODES = model.SOUNDNODES.SelectArray(s => (IPGBPUSH_SOUNDNODE)s)
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETPUSHSDK_SOUNDCARDINFO SetModel(IPGBPUSH_SOUNDCARDINFO model)
        {
            CapMixCout = model.CapMixCout;
            SOUNDNODES = model.SOUNDNODES.SelectArray(s => (NETPUSHSDK_SOUNDNODE)s);
            return this;
        }
    }
}
