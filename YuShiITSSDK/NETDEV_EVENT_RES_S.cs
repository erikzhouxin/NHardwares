using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_RES_S
    {
        public Int32 dwResType;                          /* See #NETDEV_EVENT_RES_TYPE_E */
        public Int32 dwResID;
        public Int32 dwFirstSubResID;
        public Int32 dwSecondSubResID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;
    };

}
