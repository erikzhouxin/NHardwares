using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 第三方消防系统接口信息
     * typedef struct  
     * {
     *   WORD  PinCout;//触发的信号数
     *   WORD  PinNO[IPGB_MAX_THREEFIRCOUT];//触发的信号值 (数组第一个字的最低位为第一路信号 ,第二字的最低位第17位信号...),
     *                                      //位为1表示处理此信号 (1-IPGB_MAX_THREEFIRCOUT*16)
     * }IPGBSDK_THREEFIRINFO,*LPIPGBSDK_THREEFIRINFO;
     **/
    public struct IPGBSDK_THREEFIRINFO
    {
        /// <summary>
        /// 触发的信号数
        /// </summary>
        public ushort PinCout;
        /// <summary>
        /// 触发的信号值 (数组第一个字的最低位为第一路信号 ,第二字的最低位第17位信号...)
        /// 位为1表示处理此信号 (1-IPGB_MAX_THREEFIRCOUT*16)
        /// </summary>
        public ushort[] PinNO;
    }
    /// <summary>
    /// 第三方消防系统接口信息
    /// </summary>
    public class NETAVHSDK_THREEFIRINFO
    {
        /// <summary>
        /// 触发的信号数
        /// </summary>
        public ushort PinCout;
        /// <summary>
        /// 触发的信号值 (数组第一个字的最低位为第一路信号 ,第二字的最低位第17位信号...)
        /// 位为1表示处理此信号 (1-IPGB_MAX_THREEFIRCOUT*16)
        /// </summary>
        public ushort[] PinNO;
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator NETAVHSDK_THREEFIRINFO(IPGBSDK_THREEFIRINFO model)
        {
            return new NETAVHSDK_THREEFIRINFO()
            {
                PinCout = model.PinCout,
                PinNO = model.PinNO,
            };
        }
        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator IPGBSDK_THREEFIRINFO(NETAVHSDK_THREEFIRINFO model)
        {
            return new IPGBSDK_THREEFIRINFO()
            {
                PinCout = model.PinCout,
                PinNO = model.PinNO,
            };
        }
        /// <summary>
        /// 设置模型
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public NETAVHSDK_THREEFIRINFO SetModel(IPGBSDK_THREEFIRINFO info)
        {
            this.PinNO = info.PinNO;
            this.PinCout = info.PinCout;
            return this;
        }
    }
}
