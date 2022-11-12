using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISK_INFO_LIST_S
    {
        public Int32 dwSize;                                  /*Disk number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_DISK_MAX_NUM)]
        public NETDEV_DISK_INFO_S[] astDisksInfo;             /* Disk info*/
    };

}
