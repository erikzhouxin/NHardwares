using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPersonBaseInfo
     * @brief 门禁人员基本信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BASE_INFO_S
    {
        public UInt32 udwPersonID;                    /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;         /* 姓名 */
        public UInt32 udwGender;                      /* 性别 参见枚举 NETDEV_GENDER_TYPE_E*/
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                 /* 证件信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szTelephone;     /* 联系电话 */
        public UInt32 udwCardID;                      /* 卡片编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szCardNo;        /* 卡片号码*/
        public UInt32 udwType;                        /* 人员类型  0员工  1访客*/
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;                    /* 员工信息 */
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;                      /* 访客信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                     /* 保留字段 */
    }

}
