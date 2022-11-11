using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVMonitorMemberInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_MEMBER_INFO_S
    {
        public UInt32 udwMemberID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;
        public UInt32 udwDevNum;
        public UInt32 udwMonitorStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public NETDEV_DEV_MONITOR_INFO_S[] stDevMonitorInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                          /* Reserved */
    }

}
