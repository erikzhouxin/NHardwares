using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagACSVisitLogInfo
     * @brief 访客记录信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISIT_LOG_INFO_S
    {
        public UInt32 udwLogID;                                /* 日子ID */
        public UInt32 udwVisitorID;                            /* 访客ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szVisitorName;           /* 访客姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;        /* 访客公司 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szVisitorPhone;           /* 访客电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szCardNo;                 /* 访客卡号 */
        public UInt32 udwIntervieweeID;                        /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;       /* 被访者姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;       /* 被访者部门 [1,64]字符 */
        public Int64 tScheduleStartTime;                      /* 预约来访时间 UTC时间 单位秒s */
        public Int64 tRealStartTime;                          /* 实际来访时间 UTC时间 单位秒s */
        public UInt32 udwStatus;                               /* 状态 参见枚举NETDEV_ACS_VISIT_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* 保留字段 */
    }

}
