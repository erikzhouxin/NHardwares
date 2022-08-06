using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 请求终端采播控制结构
     * typedef struct  
     * {
     *   WORD                GBlevel;   //此次广播由用户自定义的级别 1-18
     *   WORD                GBVol;     //接收终端音量 (0-100 为0时使用服务器的默认广播音量）
     *   WORD                CBVol;     //采播源终端输入音量 1-32
     *   WORD                EncType;   //编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
     *   WORD                CbSrcTmNo; //采播源终端机号
     *   WORD                PlaySec;//广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
     *   WORD                TmCout;//此次要广播的终端个数
     *   WORD                TmID[IPGB_MAX_SDKTMCOUT]; //此次要广播的终端ID
     * }IPGBSDK_GBTMCBINFO,*LPIPGBSDK_GBTMCBINFO;
     **/
    public struct IPGBSDK_GBTMCBINFO
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
        /// 采播源终端输入音量 1-32
        /// </summary>
        public ushort CBVol;
        /// <summary>
        /// 编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 采播源终端机号
        /// </summary>
        public ushort CbSrcTmNo;
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
    /// 请求终端采播控制结构
    /// </summary>
    public class NETAVHSDK_GBTMCBINFO
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
        /// 采播源终端输入音量 1-32
        /// </summary>
        public ushort CBVol;
        /// <summary>
        /// 编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 采播源终端机号
        /// </summary>
        public ushort CbSrcTmNo;
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
        public static implicit operator NETAVHSDK_GBTMCBINFO(IPGBSDK_GBTMCBINFO model)
        {
            return new NETAVHSDK_GBTMCBINFO
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                CBVol = model.CBVol,
                EncType = model.EncType,
                CbSrcTmNo = model.CbSrcTmNo,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_GBTMCBINFO(NETAVHSDK_GBTMCBINFO model)
        {
            return new IPGBSDK_GBTMCBINFO
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                CBVol = model.CBVol,
                EncType = model.EncType,
                CbSrcTmNo = model.CbSrcTmNo,
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
        public NETAVHSDK_GBTMCBINFO SetModel(IPGBSDK_GBTMCBINFO model)
        {
            GBlevel = model.GBlevel;
            GBVol = model.GBVol;
            CBVol = model.CBVol;
            EncType = model.EncType;
            CbSrcTmNo = model.CbSrcTmNo;
            PlaySec = model.PlaySec;
            TmCout = model.TmCout;
            TmID = model.TmID;
            return this;
        }
    }
}
