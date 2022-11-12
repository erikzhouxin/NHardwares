using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVVisitorInfo
     * @brief 访客信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VISITOR_INFO_S
    {
        public UInt32 udwVisitorCount;                               /* 访客人数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szCompany;                     /* 访客单位 字符串长度范围[1, 64] */
        public UInt32 udwIntervieweeID;                              /* 被访者ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

}
