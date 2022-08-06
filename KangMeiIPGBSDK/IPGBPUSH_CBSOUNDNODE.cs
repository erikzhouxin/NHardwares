using System;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 声卡混音接口信息(创建编码通道)
    /// typedef struct  
    /// {
    ///  WORD                CapMixVol;//声卡采集混音接口音量0-100 
    ///  char                CapMixName[IPGBPUSH_MAX_SoundCardNAME];//声卡采集混音接口名
    /// }IPGBPUSH_CBSOUNDNODE;
    /// </summary>
    public struct IPGBPUSH_CBSOUNDNODE
    {
        /// <summary>
        /// 声卡采集混音接口音量0-100 
        /// </summary>
        public ushort CapMixVol;

        /// <summary>
        /// 声卡采集混音接口名
        /// </summary>
        public string CapMixName;
    }
    /// <summary>
    /// 声卡混音接口信息(创建编码通道)
    /// </summary>
    public class NETPUSHSDK_CBSOUNDNODE
    {
        /// <summary>
        /// 声卡采集混音接口音量0-100 
        /// </summary>
        public ushort CapMixVol;
        /// <summary>
        /// 声卡采集混音接口名
        /// </summary>
        public string CapMixName;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETPUSHSDK_CBSOUNDNODE(IPGBPUSH_CBSOUNDNODE model)
        {
            return new NETPUSHSDK_CBSOUNDNODE()
            {
                CapMixVol = model.CapMixVol,
                CapMixName = model.CapMixName
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBPUSH_CBSOUNDNODE(NETPUSHSDK_CBSOUNDNODE model)
        {
            return new IPGBPUSH_CBSOUNDNODE()
            {
                CapMixVol = model.CapMixVol,
                CapMixName = model.CapMixName
            };
        }
    }
}
