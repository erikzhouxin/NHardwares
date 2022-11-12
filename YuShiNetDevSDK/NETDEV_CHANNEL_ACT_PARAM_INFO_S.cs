using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVChannelActParamInfo
     * @brief 通道联动
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                 /* 通道个数*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_CHANNEL_MAX)]
        public Int32[] adwChannelID;        /* 通道ID列表*/
    }

}
