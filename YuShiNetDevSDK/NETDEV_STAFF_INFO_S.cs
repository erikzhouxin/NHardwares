using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVStaffInfo
     * @brief 员工信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STAFF_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szNumber;                       /* 人员编号 字符串长度范围[1, 16] */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szBirthday;                     /* 出生日期 字符串长度范围[1,31] */
        public UInt32 udwDeptID;                                     /* 部门ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szDeptName;                    /* 部门名称 添加时可不携带 字符串长度范围[1, 64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

}
