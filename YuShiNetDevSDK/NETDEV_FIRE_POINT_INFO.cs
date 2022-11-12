using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FIRE_POINT_INFO
    {
        public Int32 udwChannelNum;                            /* 通道个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_POSTION_INFO_S[] stPositionList;  /* 火点在不同通道下的位置列表。当ChannelNum不为0时必选 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                            /* 保留字段 */
    }

}
