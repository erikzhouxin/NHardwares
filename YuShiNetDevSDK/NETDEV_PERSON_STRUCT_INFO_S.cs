using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPersonStructInfo
     * @brief 人员信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_STRUCT_INFO_S
    {
        public UInt32 udwPersonID;                                   /* 人员ID */
        public UInt32 udwPersonDoforFaceID;                          /* 人员所属人脸ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 人员位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 人员对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 人员对应的大图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szFeaturVersion;                /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 半结构化特征厂商类型版本号 采用base64编码 加密前512 Bytes */
        public NETDEV_PERSON_ATTR_S stPersonAttr;                    /* 人员信息 */
        public IntPtr pstRuleInfo;                                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
