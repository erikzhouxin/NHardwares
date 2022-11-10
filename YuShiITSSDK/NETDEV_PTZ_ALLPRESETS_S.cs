using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 所有云台预置位 结构体定义 All PTZ presets Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ALLPRESETS_S
    {
        public Int32 dwSize;                             /* 预置位总数  Total number of presets */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEMO.NETDEV_MAX_PRESET_NUM)]
        public NETDEV_PTZ_PRESET_S[] astPreset;          /* 预置位信息结构体  Structure of preset information */
    }

}
