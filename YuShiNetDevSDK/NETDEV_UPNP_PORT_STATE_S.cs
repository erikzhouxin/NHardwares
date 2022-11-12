using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_PORT_STATE_S
    {
        public NETDEV_PROTOCOL_TYPE_E eType;
        public Int32 bEnbale;
        public Int32 dwPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
