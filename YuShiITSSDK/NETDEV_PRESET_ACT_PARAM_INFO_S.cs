using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPresetActParamInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRESET_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public NETDEV_CHANNEL_PRESET_S[] stChannelPreset;
    }

}
