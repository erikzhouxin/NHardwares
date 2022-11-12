using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonInfo
    * @brief 人员信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_INFO_S
    {
        public UInt32 udwPersonID;                         /* 人员ID */
        public UInt32 udwLastChange;                       /* 人员信息最后修改时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;        /* 人员名字 范围:[1, 63] */
        public UInt32 udwGender;                           /* 成员性别 详情参见枚举NETDEV_GENDER_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szBirthday;           /* 成员出生日期，格式YYYYMMDD，范围[1,31] */
        public NETDEV_REGION_INFO_S stRegionInfo;                        /* 成员地区信息 */
        public UInt32 udwTimeTemplateNum;                  /* 时间模板数量 */
        public IntPtr pstTimeTemplateList;                 /* 时间模板相关信息 需动态分配(参见NETDEV_PERSON_TIME_TEMPLATE_INFO_S) */
        public UInt32 udwIdentificationNum;                /* 证件信息个数 范围:[0, 6]*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_8)]
        public NETDEV_IDENTIFICATION_INFO_S[] stIdentificationInfo;  /* 成员证件信息 */
        public UInt32 udwImageNum;                         /* 人脸图片个数 范围:[0, 6] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_8)]
        public NETDEV_IMAGE_INFO_S[] stImageInfo;           /* 人脸图片信息列表 */
        public UInt32 udwReqSeq;                           /* 请求数据序列号，此字段会在返回结果中待会，仅在批量添加中携带该字段 */
        public Int32 bIsMonitored;                        /* 是否已布控，获取时必带，仅VMS支持 */
        public UInt32 udwBelongLibNum;                     /* 所属人员库数量，仅VMS支持 */
        public IntPtr pudwBelongLibList;                   /* 所属人员库ID列表，需动态分配内存，仅VMS支持(UINT32*) */
        public UInt32 udwCustomNum;                        /* 自定义属性值数量，最多5个，仅VMS支持 */
        public IntPtr pstCustomValueList;                  /* 自定义属性值列表，需动态分配内存，当Num为0时可以不填（参见NETDEV_CUSTOM_VALUE_S） */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szTelephone;          /* 联系电话 字符串长度[1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szAddress;           /* 地址 字符串长度范围[1, 64] */
        public UInt32 udwCardNum;                          /* 门禁卡个数 取值范围[0,6],Get时携带 */
        public UInt32 udwFingerprintNum;                   /* 指纹个数，取值范围[0,10] */
        public UInt32 udwType;                             /* 人员类型 0：员工 1：访客 2：陌生人 */
        public NETDEV_STAFF_INFO_S stStaff;                             /* 员工信息 Type为员工时必填 */
        public NETDEV_VISITOR_INFO_S stVisitor;                           /* 访客信息 Type为访客时必填 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_480)]
        public byte[] szDesc;              /* 备注信息 字符串长度范围[1, 128] */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public string szPersonCode;         /* 人员编码，可填写学号或工号，范围:[1, 15] PTS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szRemarks;            /* 备注信息 范围:[1-63] PTS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 176)]
        public byte[] byRes;                          /* 保留字节 */
    }

}
