using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CHANNEL_LIST_S
    {
        public Int32 udwNum;                /* Channel Num */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_CHANNEL_MAX)]
        public Int32[] audwChannelList;     /* channel list*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                          /* Reserved */
    }

}
