using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IPADDR_INFO_S
    {
        public Int32 dwType;                            /* See NETDEV_IP_ADDRESS_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string szIPAddr;
        public Int32 dwPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byRes;
    };

}
