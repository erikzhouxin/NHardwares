using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVUserExtendInfo
    * @brief 用户扩展信息 结构体定义 
    * @attention 无 None
    */
    public struct NETDEV_USER_EXTEND_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szCertificateCode;                          /* 证件号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szEmail;                                    /* 邮箱号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szTelephone;                                /* 电话号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_512)]
        public byte[] szDesc;                                     /* 描述 [1,128]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szName;                                     /* 证件号码 [1,64]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 192)]
        public byte[] byRes;                                      /* 保留字段  */
    }

}
