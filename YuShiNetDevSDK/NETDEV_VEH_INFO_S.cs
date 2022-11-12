using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVVehicleInfo
     * @brief 车辆信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_INFO_S
    {
        public UInt32 udwID;                                         /* 车辆ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 车辆位置信息 */
        public UInt32 udwSmallPicAttachIndex;                       /* 车辆对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 车辆对应的大图在图像列表中的索引 */
        public UInt32 udwPlatePicAttachIndex;                        /* 车牌对应的小图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szFeatureVersion;               /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 基于人脸提取出来的特征信息 采用base64编码 加密前512 Bytes */
        public NETDEV_VEH_ATTR_S stVehAttr;                          /* 车辆属性信息 */
        public NETDEV_PLATE_ATTR_S stPlateAttr;                      /* 车牌属性信息 */
        public IntPtr pstRuleInfo;                                  /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S[] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
