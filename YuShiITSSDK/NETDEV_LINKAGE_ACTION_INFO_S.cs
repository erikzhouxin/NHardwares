using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_INFO_S
    {
        public UInt32 udwActID;
        public NETDEV_ENABLED_ACT_PARAM_INFO_S stEnabledInfo;
        public NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S stOutputSwitchActParamInfo;
        public NETDEV_CHANNEL_ACT_PARAM_INFO_S stChannelActParamInfo;
        public NETDEV_PRESET_ACT_PARAM_INFO_S stPresetActParamInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;
    }

}
