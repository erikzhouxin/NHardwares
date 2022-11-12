using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PRESET_S
    {
        public Int32 dwPresetID;                                 /* ID  Preset ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szPresetName;    /** Preset name */
    }

}
