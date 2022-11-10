using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSAttendanceLogInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_ATTENDANCE_LOG_INFO_S
    {
        public UInt32 udwAlarmType;
        public Int64 tTimeStamp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szDoorName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szDoorNo;
        public UInt32 udwDoorDirect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szCardNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPersonName;
        public UInt32 udwPersonType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPersonPhone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szPersonDept;
        public NETDEV_COMPARE_INFO_S stCompareInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
