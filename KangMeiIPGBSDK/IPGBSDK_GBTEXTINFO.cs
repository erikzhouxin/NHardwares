using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 请求TTS文本广播控制结构
     * typedef struct  
     * {
     *   WORD                   GBlevel;   //此次广播由用户自定义的级别 1-18
     *   WORD                   GBVol;     //接收终端音量 0-10
     *   WORD                   PlaySec;//广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
     *   WORD                   TmCout;//此次要广播的终端个数
     *   WORD                   TmID[IPGB_MAX_SDKTMCOUT]; //此次要广播的终端ID
     *   IPGBSDK_TTSTEXTIINFO   m_TEXT;//TTS广播文本
     * }IPGBSDK_GBTEXTINFO,*LPIPGBSDK_GBTEXTINFO;
     **/
    public struct IPGBSDK_GBTEXTINFO
    {
        /// <summary>
        /// 此次广播由用户自定义的级别 1-18
        /// </summary>
        public ushort GBlevel;
        /// <summary>
        /// 接收终端音量 0-10
        /// </summary>
        public ushort GBVol;
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
        /// TTS广播文本
        /// </summary>
        public IPGBSDK_TTSTEXTIINFO m_TEXT;
    }
    /// <summary>
    /// 请求TTS文本广播控制结构
    /// </summary>
    public class NETAVHSDK_GBTEXTINFO
    {
        /// <summary>
        /// 此次广播由用户自定义的级别 1-18
        /// </summary>
        public ushort GBlevel;
        /// <summary>
        /// 接收终端音量 0-10
        /// </summary>
        public ushort GBVol;
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
        /// TTS广播文本
        /// </summary>
        public NETAVHSDK_TTSTEXTIINFO m_TEXT;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_GBTEXTINFO(IPGBSDK_GBTEXTINFO model)
        {
            return new NETAVHSDK_GBTEXTINFO()
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID,
                m_TEXT = (NETAVHSDK_TTSTEXTIINFO)model.m_TEXT,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_GBTEXTINFO(NETAVHSDK_GBTEXTINFO model)
        {
            return new IPGBSDK_GBTEXTINFO()
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID,
                m_TEXT = (IPGBSDK_TTSTEXTIINFO)model.m_TEXT,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_GBTEXTINFO SetModel(IPGBSDK_GBTEXTINFO model)
        {
            GBlevel = model.GBlevel;
            GBVol = model.GBVol;
            PlaySec = model.PlaySec;
            TmCout = model.TmCout;
            TmID = model.TmID;
            m_TEXT = (NETAVHSDK_TTSTEXTIINFO)model.m_TEXT;
            return this;
        }
    }
}
