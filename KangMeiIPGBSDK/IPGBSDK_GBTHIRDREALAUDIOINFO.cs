using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 请求第三方实时流广播控制结构
     * typedef struct  
     * {
     *   WORD                   GBlevel;   //此次广播由用户自定义的级别 1-18
     *   WORD                   GBVol;     //接收终端音量 (0-100 为0时使用服务器的默认广播音量）
     *   WORD                   EncType;   //编码类型 EncType=1(高音质)、EncType=2(低延时)类型
     *   WORD                   AudioSrcChId;//第三方实时流编码源通道ID句柄
     *   WORD                   PlaySec;//广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
     *   WORD                   TmCout;//此次要广播的终端个数
     *   WORD                   TmID[IPGB_MAX_SDKTMCOUT]; //此次要广播的终端ID
     * }IPGBSDK_GBTHIRDREALAUDIOINFO,*LPIPGBSDK_GBTHIRDREALAUDIOINFO;
     **/
    public struct IPGBSDK_GBTHIRDREALAUDIOINFO
    {
        /// <summary>
        /// 此次广播由用户自定义的级别 1-18
        /// </summary>
        public ushort GBlevel;
        /// <summary>
        /// 接收终端音量 (0-100 为0时使用服务器的默认广播音量）
        /// </summary>
        public ushort GBVol;
        /// <summary>
        /// 编码类型 EncType=1(高音质)、EncType=2(低延时)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 第三方实时流编码源通道ID句柄
        /// </summary>
        public ushort AudioSrcChId;
        /// <summary>
        /// 广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
        /// </summary>
        public ushort PlaySec;
        /// <summary>
        /// 此次要广播的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 此次要广播的终端ID
        /// </summary>
        public ushort[] TmID;
    }
    /// <summary>
    /// 请求第三方实时流广播控制结构
    /// </summary>
    public class NETAVHSDK_GBTHIRDREALAUDIOINFO
    {
        /// <summary>
        /// 此次广播由用户自定义的级别 1-18
        /// </summary>
        public ushort GBlevel;
        /// <summary>
        /// 接收终端音量 (0-100 为0时使用服务器的默认广播音量）
        /// </summary>
        public ushort GBVol;
        /// <summary>
        /// 编码类型 EncType=1(高音质)、EncType=2(低延时)类型
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 第三方实时流编码源通道ID句柄
        /// </summary>
        public ushort AudioSrcChId;
        /// <summary>
        /// 广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
        /// </summary>
        public ushort PlaySec;
        /// <summary>
        /// 此次要广播的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 此次要广播的终端ID
        /// </summary>
        public ushort[] TmID;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_GBTHIRDREALAUDIOINFO(NETAVHSDK_GBTHIRDREALAUDIOINFO model)
        {
            return new IPGBSDK_GBTHIRDREALAUDIOINFO
            {
                AudioSrcChId = model.AudioSrcChId,
                EncType = model.EncType,
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_GBTHIRDREALAUDIOINFO(IPGBSDK_GBTHIRDREALAUDIOINFO model)
        {
            return new NETAVHSDK_GBTHIRDREALAUDIOINFO
            {
                AudioSrcChId = model.AudioSrcChId,
                EncType = model.EncType,
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_GBTHIRDREALAUDIOINFO SetModel(IPGBSDK_GBTHIRDREALAUDIOINFO model)
        {
            AudioSrcChId = model.AudioSrcChId;
            EncType = model.EncType;
            GBlevel = model.GBlevel;
            GBVol = model.GBVol;
            PlaySec = model.PlaySec;
            TmCout = model.TmCout;
            TmID = model.TmID;
            return this;
        }
    }
}
