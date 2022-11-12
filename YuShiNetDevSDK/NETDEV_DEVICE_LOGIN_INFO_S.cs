using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_LOGIN_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public string szIPAddr;       /* IP地址/域名 */
        public Int32 dwPort;                         /* 端口号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_132)]
        public string szUserName;     /* 用户名 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public string szPassword;     /* 密码 */
        public Int32 dwLoginProto;                   /* 登录协议, 参见NETDEV_LOGIN_PROTO_E */
        public Int32 dwDeviceType;                   /* 设备类型, 参见NETDEV_DEVICE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* Reserved */
    };

}
