using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagACSVisitLogInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISIT_LOG_INFO_S
    {
        public UInt32 udwLogID;
        public UInt32 udwVisitorID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szVisitorName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szVisitorPhone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szCardNo;
        public UInt32 udwIntervieweeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;
        public Int64 tScheduleStartTime;
        public Int64 tRealStartTime;
        public UInt32 udwStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
