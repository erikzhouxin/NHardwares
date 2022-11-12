using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVNonMotorVehInfo
     * @brief 非机动车信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NON_MOTOR_VEH_INFO_S
    {
        public UInt32 udwID;                                         /* 非机动车ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 非机动车位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 非机动车对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 非机动对应的大图在图像列表中的索引 */
        public NETDEV_NO_MOTOR_VEH_ATTR_S stNoMotorVehAttr;          /* 非机动车属性信息 */
        public UInt32 udwPersonOnNoVehiNum;                          /* 驾乘人员数目 */
        public IntPtr pstPersonAttr;                 /* 人员属性 需动态申请内存(NETDEV_PERSON_ATTR_S[]) */
        public IntPtr pstRuleInfo;                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S[] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
