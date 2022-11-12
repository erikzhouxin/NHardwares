using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSAttendanceLogInfo
     * @brief 出入记录信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_ATTENDANCE_LOG_INFO_S
    {
        public UInt32 udwAlarmType;                    /* 告警类型 */
        public Int64 tTimeStamp;                      /* 告警时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szDoorName;      /* 门名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szDoorNo;         /* 门编号 */
        public UInt32 udwDoorDirect;                   /* 进出方向 0:进,1:出 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szCardNo;         /* 刷卡卡号*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szPersonName;    /* 刷卡人姓名 */
        public UInt32 udwPersonType;                   /* 人员类型  参见NETDEV_ACS_PERSON_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPersonPhone;    /* 刷卡人电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szPersonDept;    /* 刷卡人部门 */
        public NETDEV_COMPARE_INFO_S stCompareInfo;    /* 脸对比信息，速通门会携带此信息 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段 */
    }

}
