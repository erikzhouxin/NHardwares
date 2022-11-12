using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceMemberInfo
     * @brief 人脸库成员信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_INFO_S
    {
        public UInt32 udwReqSeq;                                                   /* 请求数据序号 */
        public UInt32 udwMemberID;                                                 /*人脸库成员ID   只读 post消息时不带*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_NAME_LEN)]
        public byte[] szMemberName;                   /* 成员名称 */
        public UInt32 udwMemberGender;                                             /* 成员性别 参见枚举 NETDEV_GENDER_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_BIRTHDAY_LEN)]
        public string szMemberBirthday;           /* 成员出生日期 */
        public NETDEV_FACE_MEMBER_REGION_INFO_S stMemberRegionInfo;                /* 成员地区信息 */
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;                    /* 成员证件信息 */
        public NETDEV_FILE_INFO_S stMemberImageInfo;                 /* 人脸图片信息 */
        public NETDEV_FILE_INFO_S stMemberSemiInfo;                  /* 人脸半结构化信息 */
        public UInt32 udwCustomNum;                                                /* 自定义属性值数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_CUSTOM_NUM)]
        public NETDEV_CUSTOM_VALUE_S[] stCustomValue;        /* 自定义属性值列表 */
        public Int32 bIsMonitored;                                               /* 是否已布控  0未布控，1已布控 */
        public UInt32 udwDBNum;                                                   /* 所属人脸库数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;                                /* 人脸库ID列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                                 /* 保留字段  Reserved */

    }

}
