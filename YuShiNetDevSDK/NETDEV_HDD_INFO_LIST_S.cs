using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_INFO_LIST_S
    {
        public Int32 dwSize;                             /* 硬盘个数 Disk number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public NETDEV_HDD_INFO_S[] astHDDInfo;          /* 硬盘信息 Disk info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                        /* Reserved */
    }

}
