using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 协议信息列表  Protocol info list
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_NAT_STATE_S
    {
        public Int32 dwSize;                                 /* 协议个数  Number of protocols */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_UPNP_PORT_STATE_S[] astUpnpPort;       /* 协议信息  Protocol info */
    }

}
