using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMemberInfo
     * @brief 人脸/车辆成员信息列表 结构体定义
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MEMBER_INFO_S
    {
        public UInt32 udwMemberID;                              /* 人脸/车辆成员ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szMemberName;                             /* 人脸/车辆成员名称，范围[1,63] */
        public UInt32 udwStatus;                                /* 成员同步状态 人脸参考: NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

}
