using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_NAT_STATE_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_UPNP_PORT_STATE_S[] astUpnpPort;
    }

}
