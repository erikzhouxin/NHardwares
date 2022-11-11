using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CLOUD_DEV_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_IPV4_LEN_MAX)]
        public char[] szIPAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public char[] szDevUserName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public char[] szDevName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public char[] szDevModel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public char[] szDevSerialNum;

        public Int32 dwOrgID;                                    /* Organization ID */
        public Int32 dwDevPort;
    }

}
