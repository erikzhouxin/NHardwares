using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 创建声卡音频采集编码源通道信息,用于声卡广播
     * typedef struct  
     * {
     * 	WORD                EncType;//编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
     * 	WORD                SoundCarMixVol;//声卡采集混音接口音量0-100
     * 	char                SoundCarMixName[IPGB_MAX_SoundCardNAME];//声卡采集混音接口名
     * }IPGBSDK_SoundCarSrcINFO,LPIPGBSDK_SoundCarSrcINFO;
     **/
    public struct IPGBSDK_SoundCarSrcINFO
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 声卡采集混音接口音量0-100
        /// </summary>
        public ushort SoundCarMixVol;
        /// <summary>
        /// 声卡采集混音接口名
        /// </summary>
        public string SoundCarMixName;
    }
    /// <summary>
    /// 创建声卡音频采集编码源通道信息,用于声卡广播
    /// </summary>
    public class NETAVHSDK_SoundCarSrcINFO
    {
        /// <summary>
        /// 编码类型  EncType=1(高音质-mp3)、EncType=2(低延时- adpcm 22050采样)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 声卡采集混音接口音量0-100
        /// </summary>
        public ushort SoundCarMixVol;
        /// <summary>
        /// 声卡采集混音接口名
        /// </summary>
        public string SoundCarMixName;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_SoundCarSrcINFO(NETAVHSDK_SoundCarSrcINFO model)
        {
            return new IPGBSDK_SoundCarSrcINFO
            {
                EncType = model.EncType,
                SoundCarMixName = model.SoundCarMixName,
                SoundCarMixVol = model.SoundCarMixVol,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_SoundCarSrcINFO(IPGBSDK_SoundCarSrcINFO model)
        {
            return new NETAVHSDK_SoundCarSrcINFO
            {
                EncType = model.EncType,
                SoundCarMixName = model.SoundCarMixName,
                SoundCarMixVol = model.SoundCarMixVol,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_SoundCarSrcINFO SetModel(IPGBSDK_SoundCarSrcINFO model)
        {
            EncType = model.EncType;
            SoundCarMixName = model.SoundCarMixName;
            SoundCarMixVol = model.SoundCarMixVol;
            return this;
        }
    }
}
