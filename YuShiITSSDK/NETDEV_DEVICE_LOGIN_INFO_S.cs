using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_LOGIN_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public string szIPAddr;
        public Int32 dwPort;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_132)]
        public string szUserName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public string szPassword;
        public Int32 dwLoginProto;                   /* See NETDEV_LOGIN_PROTO_E */
        public Int32 dwDeviceType;                   /* See NETDEV_DEVICE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                              /* Reserved */
    };

}
