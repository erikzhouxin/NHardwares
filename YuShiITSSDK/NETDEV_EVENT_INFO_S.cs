using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_INFO_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public NETDEV_EVENT_RES_S[] astEventRes;
        public Int32 dwEventActionType;                          /* See #NETDEV_EVENT_ACTION_TYPE_E */
        public IntPtr pstEventRes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] byRes;
    };

}
