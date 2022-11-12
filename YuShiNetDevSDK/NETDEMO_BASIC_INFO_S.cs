using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEMO_BASIC_INFO_S
    {
        public bool existFlag;
        public NETDEV_TIME_CFG_S stSystemTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public String szDeviceName;
        public NETDEV_DISK_INFO_LIST_S stDiskInfoList;
    }
}
