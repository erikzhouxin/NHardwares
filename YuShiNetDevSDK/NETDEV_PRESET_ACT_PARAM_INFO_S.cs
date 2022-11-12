using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPresetActParamInfo
     * @brief 联动云台预置位
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRESET_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                                      /* 联动动作数量*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_CHANNEL_MAX)]
        public NETDEV_CHANNEL_PRESET_S[] stChannelPreset;        /* 联动到预置位信息列表*/
    }

}
