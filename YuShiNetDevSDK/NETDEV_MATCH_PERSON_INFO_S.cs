using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVMatchPersonInfo
    * @brief 匹配人员信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MATCH_PERSON_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;        /* 成员名字 范围[1,63] */
        public UInt32 udwGender;                           /* 成员性别 详情参见枚举NETDEV_GENDER_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szCardID;             /* 门禁卡号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szIdentityNo;         /* 身份证卡号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPersonCode;         /* 人员编码 可填写学号或工号 范围:[1, 15] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                           /* 保留字节 */
    }

}
