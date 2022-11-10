using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_USER_SIMPLE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string szUserName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szPassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    };

}
