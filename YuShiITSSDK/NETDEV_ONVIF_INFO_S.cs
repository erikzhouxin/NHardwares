using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ONVIF_INFO_S
    {
        public Int32 udwTransportMode;                          /*See NETDEV_TRANS_PROTOCOL_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
