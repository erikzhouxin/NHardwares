using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 调节终端输出音量
     * typedef struct  
     * {
     * 	WORD  TmCout;//终端个数
     * 	WORD  TmId[IPGB_MAX_SETVOL_COUT];
     * 	WORD  TmVol;//音量值 (0-100)
     * 	WORD  SetType;   //调节类型  1:只修改当前终端音量  2:修改当前终端音量并保存为默认广播音量 (此项需要用户权限为18级)
     * }IPGBSDK_SET_TMVOL,*LPIPGBSDK_SET_TMVOL;
     **/
    public struct IPGBSDK_SET_TMVOL
    {
        /// <summary>
        /// 终端个数
        /// </summary>
        public uint TmCout;
        /// <summary>
        /// 终端标识
        /// </summary>
        public ushort[] TmId;
        /// <summary>
        /// 音量值 (0-100)
        /// </summary>
        public ushort TmVol;
        /// <summary>
        /// 调节类型  1:只修改当前终端音量  2:修改当前终端音量并保存为默认广播音量 (此项需要用户权限为18级)
        /// </summary>
        public ushort SetType;
    }
    /// <summary>
    /// 调节终端输出音量
    /// </summary>
    public class NETAVHSDK_SET_TMVOL
    {
        /// <summary>
        /// 终端个数
        /// </summary>
        public uint TmCout;
        /// <summary>
        /// 终端标识
        /// </summary>
        public ushort[] TmId;
        /// <summary>
        /// 音量值 (0-100)
        /// </summary>
        public ushort TmVol;
        /// <summary>
        /// 调节类型  1:只修改当前终端音量  2:修改当前终端音量并保存为默认广播音量 (此项需要用户权限为18级)
        /// </summary>
        public ushort SetType;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_SET_TMVOL(NETAVHSDK_SET_TMVOL model)
        {
            return new IPGBSDK_SET_TMVOL()
            {
                TmCout = model.TmCout,
                TmId = model.TmId,
                TmVol = model.TmVol,
                SetType = model.SetType,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_SET_TMVOL(IPGBSDK_SET_TMVOL model)
        {
            return new NETAVHSDK_SET_TMVOL()
            {
                TmCout = model.TmCout,
                TmId = model.TmId,
                TmVol = model.TmVol,
                SetType = model.SetType,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public NETAVHSDK_SET_TMVOL SetModel(IPGBSDK_SET_TMVOL model)
        {
            TmCout = model.TmCout;
            TmId = model.TmId;
            TmVol = model.TmVol;
            SetType = model.SetType;
            return this;
        }
    }
}
