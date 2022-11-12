using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSStaffInfo
     * @brief 员工信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_STAFF_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szNumber;                               /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_BIRTHDAY_LEN)]
        public byte[] szBirthday;           /* 出生日期 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szDeptName;                            /* 部门名称*/
        public UInt32 udwDeptID;                                             /* 部门ID */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                            /* 保留字段 */
    }

}
