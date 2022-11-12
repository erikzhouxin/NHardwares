using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceMemberIDInfo
     * @brief 成员证件信息 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_ID_INFO_S
    {
        public UInt32 udwType;                                       /*证件类型 参见枚举 NETDEV_FACE_MEMBER_ID_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_FACE_IDNUMBER_LEN)]
        public string szNumber;            /* 证件号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                     /* 保留字段  Reserved */
    }

}
