using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVTVwallCode
     * @brief 电视墙编码 结构体定义 
     * @attention 无 None
     */
    public struct NETDEV_TVWALL_CODE_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szTVwallCode;   /* 电视墙编码，字符串长度范围[1, 64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;          /* 保留字段 */
    };

}
