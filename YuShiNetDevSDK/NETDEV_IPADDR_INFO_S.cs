using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IPADDR_INFO_S
    {
        public Int32 dwType;                            /* 地址类型，参见枚举NETDEV_IP_ADDRESS_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string szIPAddr;      /* IP地址/域名 */
        public Int32 dwPort;                            /* 端口号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byRes;
    };

}
