using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ORIENTATION_INFO_S
    {
        public Int32 dwDirection;/* Direction Info see enumeration #NETDEV_PTZ_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;              /* Reserved field*/
    };

}
