using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVACSPersonInfo
     * @brief 门禁人员信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_INFO_S
    {
        public UInt32 udwReqSeq;                          /* 请求序号 */
        public UInt32 udwPersonID;                        /* 人员编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;             /* 姓名 */
        public UInt32 udwGender;                          /* 性别 参见枚举 NETDEV_GENDER_TYPE_E*/
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                     /* 证件信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szTelephone;         /* 联系电话 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szAddress;          /* 地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_480)]
        public byte[] szDesc;             /* 备注 */

        public UInt32 udwCardNum;                         /* 门禁卡个数，取值范围[1,6] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_6)]
        public NETDEV_ACS_PERSON_CARD_INFO_S[] stACSPersonCardList;    /* 门禁卡信息 */
        public NETDEV_ACS_FACE_IMAGE_S stFaceImage;                        /* 人脸图片 */
        public UInt32 udwType;                            /* 人员类型  参见NETDEV_ACS_PERSON_TYPE_E*/
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;                        /* 员工信息 */
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;                          /* 访客信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

}
