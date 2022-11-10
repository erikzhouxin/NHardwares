using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 协议信息  Protocol info
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_UPNP_PORT_STATE_S
    {
        public NETDEV_PROTOCOL_TYPE_E eType;              /* 协议类型参见枚举# NETDEV_PROTOCOL_TYPE_E  Protocol type, see enumeration #NETDEV_PROTOCOL_TYPE_E */
        public Int32 bEnbale;                             /* 是否支持  Supported or not */
        public Int32 dwPort;                              /* 端口号  Port number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                              /* 保留字段  Reserved */
    }

}
