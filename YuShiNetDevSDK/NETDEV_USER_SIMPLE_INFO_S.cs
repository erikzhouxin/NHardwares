using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_USER_SIMPLE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string szUserName;       /* 用户名 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szPassword;       /* 密码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    };

}
