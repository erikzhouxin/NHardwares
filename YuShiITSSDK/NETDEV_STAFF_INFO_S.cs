using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVStaffInfo
     * @brief 
     * @attention  None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STAFF_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public string szNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public string szBirthday;
        public UInt32 udwDeptID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szDeptName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                    /* Reserved */
    }

}
