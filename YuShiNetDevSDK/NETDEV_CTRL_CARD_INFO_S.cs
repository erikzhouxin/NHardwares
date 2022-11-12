using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tafNETDEVCtrlCardInfo
    * @brief 卡信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_CARD_INFO_S
    {
        public UInt32 udwID;                                       /* 记录ID */
        public UInt32 udwTimestamp;                                /* 采集时间 UTC格式，单位秒 */
        public UInt32 udwCapSrc;                                   /* 采集来源 详见 NETDEV_CAP_SRC_E CardInfo选择2或3*/
        public UInt32 udwCardType;                                 /* 0：身份证，1：门禁卡*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szCardID;                     /* 门禁卡字段：物理卡号 最长18位*/
        public UInt32 udwCardStatus;                               /* 门禁卡字段：卡状态 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szName;                      /* 身份证字段：姓名 范围[1,63] */
        public UInt32 udwGender;                                   /* 身份证字段：性别 详情参见枚举NETDEV_GENDER_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szBirthday;                   /* 身份证字段：出生日期 YYYYMMDD */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public byte[] szResidentialAddress;        /* 身份证字段：住址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szIdentityNo;                 /* 身份证字段：身份证号码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public byte[] szIssuingAuthority;          /* 身份证字段：发证机关 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szIssuingDate;                /* 身份证字段：发证日期 YYYYMMDD */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szValidDateStart;             /* 身份证字段：证件有效期开始时间 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public byte[] szValidDateEnd;               /* 身份证字段：证件有效期结束时间 */
        public NETDEV_FILE_INFO_S stIDImage;                       /* 身份证照片 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;                                  /* 保留字节 */
    }

}
