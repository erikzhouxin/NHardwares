using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * TTS文本转语音信息
     * typedef struct  
     * {
     *   BYTE  TTStype;//TTS解码声音类型 1:女声;2:男声
     *   BYTE  TTSPlayCout;//TTS解码播放次数(最大99次)
     *   WORD  TextLen;//文本长度(字节数 最长为 IPGB_MAX_TTSTEXTLEN)
     *   char  TEXT[IPGB_MAX_TTSTEXTLEN];//文本内容
     * }IPGBSDK_TTSTEXTIINFO,*LPIPGBSDK_TTSTEXTIINFO;
     **/
    public struct IPGBSDK_TTSTEXTIINFO
    {
        /// <summary>
        /// TTS解码声音类型 1:女声;2:男声
        /// </summary>
        public byte TTStype;
        /// <summary>
        /// TTS解码播放次数(最大99次)
        /// </summary>
        public byte TTSPlayCout;
        /// <summary>
        /// 文本长度(字节数 最长为 IPGB_MAX_TTSTEXTLEN)
        /// </summary>
        public ushort TextLen;
        /// <summary>
        /// 文本内容
        /// </summary>
        public string TEXT;
    }
    /// <summary>
    /// TTS文本转语音信息
    /// </summary>
    public class NETAVHSDK_TTSTEXTIINFO
    {
        /// <summary>
        /// TTS解码声音类型 1:女声;2:男声
        /// </summary>
        public byte TTStype;
        /// <summary>
        /// TTS解码播放次数(最大99次)
        /// </summary>
        public byte TTSPlayCout;
        /// <summary>
        /// 文本长度(字节数 最长为 IPGB_MAX_TTSTEXTLEN)
        /// </summary>
        public ushort TextLen;
        /// <summary>
        /// 文本内容
        /// </summary>
        public string TEXT;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_TTSTEXTIINFO(NETAVHSDK_TTSTEXTIINFO model)
        {
            return new IPGBSDK_TTSTEXTIINFO
            {
                TEXT = model.TEXT,
                TextLen = model.TextLen,
                TTSPlayCout = model.TTSPlayCout,
                TTStype = model.TTStype,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_TTSTEXTIINFO(IPGBSDK_TTSTEXTIINFO model)
        {
            return new NETAVHSDK_TTSTEXTIINFO
            {
                TEXT = model.TEXT,
                TextLen = model.TextLen,
                TTSPlayCout = model.TTSPlayCout,
                TTStype = model.TTStype,
            };
        }
    }
}
