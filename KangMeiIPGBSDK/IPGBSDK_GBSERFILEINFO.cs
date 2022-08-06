using System;
using System.Linq;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 请求服器文件广播控制结构
     * typedef struct  
     * {
     *   WORD                GBlevel;   //此次广播由用户自定义的级别 1-18
     *   WORD                GBVol;     //接收终端音量 (0-100 为0时使用服务器的默认广播音量）
     *   WORD                TmCout;//此次要广播的终端个数
     *   WORD                TmID[IPGB_MAX_SDKTMCOUT]; //此次要广播的终端ID
     *   WORD                PlayLoop;//文件广播是否循环播放1:为是
     *   WORD                PlaySec;//广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
     *   WORD                     FileCout; //文件广播中文件资源数组个数     选择的广播文件(注意选择必须是128Kb/s CBR MP3文件)
     *   IPGBSDK_SER_ONEFILEINFO  m_OneFile[IPGB_MAX_GBFILE];//文件广播的服务器文件资源数组
     * }IPGBSDK_GBSERFILEINFO,*LPIPGBSDK_GBSERFILEINFO;
     **/
    public struct IPGBSDK_GBSERFILEINFO
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
        /// 此次要广播的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 此次要广播的终端ID
        /// </summary>
        public ushort[] TmID;
        /// <summary>
        /// 文件广播是否循环播放1:为是
        /// </summary>
        public ushort PlayLoop;
        /// <summary>
        /// 广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
        /// </summary>
        public ushort PlaySec;
        /// <summary>
        /// 文件广播中文件资源数组个数     选择的广播文件(注意选择必须是128Kb/s CBR MP3文件)
        /// </summary>
        public ushort FileCout;
        /// <summary>
        /// 文件广播的服务器文件资源数组
        /// </summary>
        public IPGBSDK_SER_ONEFILEINFO[] m_OneFile;
    }
    /// <summary>
    /// 请求服器文件广播控制结构
    /// </summary>
    public class NETAVHSDK_GBSERFILEINFO
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
        /// 此次要广播的终端个数
        /// </summary>
        public ushort TmCout;
        /// <summary>
        /// 此次要广播的终端ID
        /// </summary>
        public ushort[] TmID;
        /// <summary>
        /// 文件广播是否循环播放1:为是
        /// </summary>
        public ushort PlayLoop;
        /// <summary>
        /// 广播时长控制单元秒，超过时间自动退出广播 (值当为0时，无时间控制)
        /// </summary>
        public ushort PlaySec;
        /// <summary>
        /// 文件广播中文件资源数组个数     选择的广播文件(注意选择必须是128Kb/s CBR MP3文件)
        /// </summary>
        public ushort FileCout;
        /// <summary>
        /// 文件广播的服务器文件资源数组
        /// </summary>
        public NETAVHSDK_ONEFILEINFO[] m_OneFile;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_GBSERFILEINFO(IPGBSDK_GBSERFILEINFO model)
        {
            return new NETAVHSDK_GBSERFILEINFO
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                FileCout = model.FileCout,
                m_OneFile = model.m_OneFile.SelectArray(s => (NETAVHSDK_ONEFILEINFO)s),
                PlayLoop = model.PlayLoop,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_GBSERFILEINFO(NETAVHSDK_GBSERFILEINFO model)
        {
            return new IPGBSDK_GBSERFILEINFO
            {
                GBlevel = model.GBlevel,
                GBVol = model.GBVol,
                FileCout = model.FileCout,
                m_OneFile = model.m_OneFile.SelectArray(s => (IPGBSDK_SER_ONEFILEINFO)s),
                PlayLoop = model.PlayLoop,
                PlaySec = model.PlaySec,
                TmCout = model.TmCout,
                TmID = model.TmID
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_GBSERFILEINFO SetModel(IPGBSDK_GBSERFILEINFO model)
        {
            GBlevel = model.GBlevel;
            GBVol = model.GBVol;
            FileCout = model.FileCout;
            m_OneFile = model.m_OneFile.SelectArray(s => (NETAVHSDK_ONEFILEINFO)s);
            PlayLoop = model.PlayLoop;
            PlaySec = model.PlaySec;
            TmCout = model.TmCout;
            TmID = model.TmID;
            return this;
        }
    }
}
