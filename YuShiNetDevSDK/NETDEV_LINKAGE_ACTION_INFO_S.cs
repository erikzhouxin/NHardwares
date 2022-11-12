using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVLinkageActionList
     * @brief 联动动作列表
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LINKAGE_ACTION_INFO_S
    {
        public UInt32 udwActID;                                                   /* 联动动作ID，参见枚举值NETDEV_ALARM_ACT_ID_E */
        public NETDEV_ENABLED_ACT_PARAM_INFO_S stEnabledInfo;                     /* 联动参数使能标记，适用于联动蜂鸣器、联动EMail、联动告警弹窗、 */
        public NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S stOutputSwitchActParamInfo;   /* 联动开关量输出*/
        public NETDEV_CHANNEL_ACT_PARAM_INFO_S stChannelActParamInfo;              /* 联动NVR预览、联动存储、联动抓拍 */
        public NETDEV_PRESET_ACT_PARAM_INFO_S stPresetActParamInfo;               /* 联动云台预置位 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;         /* 保留字段 */
    }

}
