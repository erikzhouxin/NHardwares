using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVACSVisitorInfo
    * @brief 访客信息
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISITOR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;       /* 访客公司 [1,64]字符 */
        public UInt32 udwVisitorCount;                        /* 访客人数 */
        public UInt32 udwIntervieweeID;                       /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;      /* 被访者姓名 [1,64]字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;      /* 被访者部门 [1,64]字符 */
        public NETDEV_ACS_TIME_SECTION_S tScheduleTime;     /* 预约访问时间 */
        public NETDEV_ACS_TIME_SECTION_S tRealTime;         /* 实际到访时间 */
        public UInt32 udwStatus;                              /* 状态 参见枚举NETDEV_ACS_VISIT_STATUS_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                             /* 保留字段 */
    }

}
