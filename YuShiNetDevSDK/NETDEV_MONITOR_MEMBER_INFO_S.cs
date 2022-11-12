using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVMonitorMemberInfo
    * @brief 成员布控状态信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_MEMBER_INFO_S
    {
        public UInt32 udwMemberID;                        /* 成员ID */
        public UInt32 udwMonitorNum;                          /* 布控数量 */
        public UInt32 udwMonitorResult;                   /* 布控总结果 0:布控失败 1:布控成功 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;             /* 成员名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_MONITOR_STATUS_INFO_S[] stMonitorStatusInfo;    /* 布控状态信息列表 目前设备数量最大为5*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                          /* 保留字段  Reserved */
    }

}
