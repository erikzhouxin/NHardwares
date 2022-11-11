using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVMonitorRuleInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_RULE_INFO_S
    {
        public Int32 bEnabled;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN)]
        public byte[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN)]
        public byte[] szReason;
        public UInt32 udwLibNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public UInt32[] audwLibList;
        public UInt32 udwMonitorType;
        public UInt32 udwMultipleValue;
        public UInt32 udwMonitorReason;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_512)]
        public byte[] szMatchSucceedMsg;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_512)]
        public byte[] szMatchFailedMsg;
        public UInt32 udwMemberNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public NETDEV_MEMBER_INFO_S[] stMemberInfo;
        public UInt32 udwChannelNum;
        public IntPtr pudwMonitorChlIDList;
        public UInt32 udwDevNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwMonitorDevIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 244)]
        public byte[] byRes;                                            /* Reserved */
    }

}
