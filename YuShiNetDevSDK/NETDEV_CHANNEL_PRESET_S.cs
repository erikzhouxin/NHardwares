using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVChannelPreset
     * @brief 联动云台预置位
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_PRESET_S
    {
        public Int32 dwChannelID;                              /* 通道号*/
        public Int32 dwPresetID;                               /* 预置位编号*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段 */
    }

}
