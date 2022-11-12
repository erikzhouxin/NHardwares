using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ALLPRESETS_S
    {
        public Int32 dwSize;                             /* Total number of presets */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_PRESET_NUM)]
        public NETDEV_PTZ_PRESET_S[] astPreset;   /* Structure of preset information */
    }

}
