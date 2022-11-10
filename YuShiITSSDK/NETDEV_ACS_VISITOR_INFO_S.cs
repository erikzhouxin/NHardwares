using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVACSVisitorInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_VISITOR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szVisitorCompany;
        public UInt32 udwVisitorCount;
        public UInt32 udwIntervieweeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szIntervieweeDept;
        public NETDEV_ACS_TIME_SECTION_S tScheduleTime;
        public NETDEV_ACS_TIME_SECTION_S tRealTime;
        public UInt32 udwStatus;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
