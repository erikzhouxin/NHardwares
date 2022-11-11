using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CLOUD_DEV_LOGIN_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public string szDeviceName;                   								/* Device name */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szDevicePassword;               								/* Device password */
        public Int32 dwT2UTimeout;                                 					/* T2U Time out,default 15s */
        public Int32 dwConnectMode;                      							/* Connect Mode  see NETDEV_CLOUD_CONNECT_MODE */
        public Int32 dwLoginProto;      	                    					/* protocol,see NETDEV_LOGIN_PROTO_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 252)]
        public string byRes;                                 					/* Reserved */

    };

}
