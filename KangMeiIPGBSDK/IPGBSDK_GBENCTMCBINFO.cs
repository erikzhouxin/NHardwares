using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
	 * 请求编码终端采播控制结构
	 * typedef struct  
	 * {
	 *   WORD                GBlevel;   //此次广播由用户自定义的级别 1-18
	 *   WORD                GBVol;     //接收终端音量 (0-100 为0时使用服务器的默认广播音量）
	 *   WORD                CBVol;     //采播源编码终端输入音量 1-32  
	 *   WORD                EncType;   //编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
	 *   WORD                CbSrcTmNo; //采播源编码终端机号 (注意此必须是编码终端)
	 *   WORD                POWType;   //启动广播是否控制时序电源其控制类型  
	 *                                  //0:不控制 
	 *                                  //1:打开"POWVal"位的对应通道,停止采播后不关电源
	 *                                  //2:打开"POWVal"位的对应通道,停止采播后关电源
	 *                                  //3:按时序全开电源通道,停止采播后不关电源
	 *                                  //4:按时序全开电源通道,停止采播后关电源
	 *   WORD                POWVal;    //电源通道对应位,变量低位为第一通道，位为1时标识(当POWType为1和2时)开电源,最多支持8路
	 *   WORD                PlaySec;   //广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
	 *   WORD                TmCout;    //此次要广播的终端个数
	 *   WORD                TmID[IPGB_MAX_SDKTMCOUT]; //此次要广播的终端ID
	 *   }IPGBSDK_GBENCTMCBINFO,*LPIPGBSDK_GBENCTMCBINFO;
	 **/
    public struct IPGBSDK_GBENCTMCBINFO
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
        /// 采播源编码终端输入音量 1-32  
        /// </summary>
        public ushort CBVol;
        /// <summary>
        /// 编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 采播源编码终端机号 (注意此必须是编码终端)
        /// </summary>
        public ushort CbSrcTmNo;
        /// <summary>
        /// 启动广播是否控制时序电源其控制类型
        /// 0:不控制 
        /// 1:打开"POWVal"位的对应通道,停止采播后不关电源
        /// 2:打开"POWVal"位的对应通道,停止采播后关电源
        /// 3:按时序全开电源通道,停止采播后不关电源
        /// 4:按时序全开电源通道,停止采播后关电源
        /// </summary>
        public ushort POWType;
        /// <summary>
        /// 电源通道对应位,变量低位为第一通道，位为1时标识(当POWType为1和2时)开电源,最多支持8路
        /// </summary>
        public ushort POWVal;
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
    /// 请求编码终端采播控制结构
    /// </summary>
    public class NETAVHSDK_GBENCTMCBINFO
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
        /// 采播源编码终端输入音量 1-32  
        /// </summary>
        public ushort CBVol;
        /// <summary>
        /// 编码类型  可选择1(高音质-ogg),可选择2(高音质-mp3),3(低延时1-12K采样),4(低延时2-32K采样)
        /// </summary>
        public ushort EncType;
        /// <summary>
        /// 采播源编码终端机号 (注意此必须是编码终端)
        /// </summary>
        public ushort CbSrcTmNo;
        /// <summary>
        /// 启动广播是否控制时序电源其控制类型
        /// 0:不控制 
        /// 1:打开"POWVal"位的对应通道,停止采播后不关电源
        /// 2:打开"POWVal"位的对应通道,停止采播后关电源
        /// 3:按时序全开电源通道,停止采播后不关电源
        /// 4:按时序全开电源通道,停止采播后关电源
        /// </summary>
        public ushort POWType;
        /// <summary>
        /// 电源通道对应位,变量低位为第一通道，位为1时标识(当POWType为1和2时)开电源,最多支持8路
        /// </summary>
        public ushort POWVal;
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
        /// <param name="info"></param>
        public static implicit operator NETAVHSDK_GBENCTMCBINFO(IPGBSDK_GBENCTMCBINFO info)
        {
            return new NETAVHSDK_GBENCTMCBINFO
            {
                GBlevel = info.GBlevel,
                GBVol = info.GBVol,
                CBVol = info.CBVol,
                EncType = info.EncType,
                CbSrcTmNo = info.CbSrcTmNo,
                PlaySec = info.PlaySec,
                POWType = info.POWType,
                POWVal = info.POWVal,
                TmCout = info.TmCout,
                TmID = info.TmID,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="info"></param>
        public static implicit operator IPGBSDK_GBENCTMCBINFO(NETAVHSDK_GBENCTMCBINFO info)
        {
            return new IPGBSDK_GBENCTMCBINFO
            {
                GBlevel = info.GBlevel,
                GBVol = info.GBVol,
                CBVol = info.CBVol,
                EncType = info.EncType,
                CbSrcTmNo = info.CbSrcTmNo,
                PlaySec = info.PlaySec,
                POWType = info.POWType,
                POWVal = info.POWVal,
                TmCout = info.TmCout,
                TmID = info.TmID,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public NETAVHSDK_GBENCTMCBINFO SetModel(IPGBSDK_GBENCTMCBINFO info)
        {
            GBlevel = info.GBlevel;
            GBVol = info.GBVol;
            CBVol = info.CBVol;
            EncType = info.EncType;
            CbSrcTmNo = info.CbSrcTmNo;
            PlaySec = info.PlaySec;
            POWType = info.POWType;
            POWVal = info.POWVal;
            TmCout = info.TmCout;
            TmID = info.TmID;
            return this;
        }
    }
}
