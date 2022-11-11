using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 地址 结构体定义 Address Structure definition 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_IPADDR_S
    {
        public Int32 eIPType;                        /* 协议类型参见枚举#NETDEV_HOSTTYPE_E  Protocol type, see enumeration #NETDEV_HOSTTYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_132)]
        public string szIPAddr;                      /* IP地址  IP address */
    }

}
