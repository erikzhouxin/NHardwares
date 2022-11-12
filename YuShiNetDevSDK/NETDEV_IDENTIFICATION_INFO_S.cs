using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVIdentificationInfo
    * @brief 成员证件信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IDENTIFICATION_INFO_S
    {
        public UInt32 udwType;                     /* 证件类型 详情参见枚举 NETDEV_ID_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public string szNumber;     /* 证件号，范围:[1, 20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                  /* 保留字节 */
    }

}
