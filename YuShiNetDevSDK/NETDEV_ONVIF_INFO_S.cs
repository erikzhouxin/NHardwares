using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ONVIF_INFO_S
    {
        public Int32 udwTransportMode;                          /* 传输模式，参见枚举NETDEV_TRANS_PROTOCOL_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
