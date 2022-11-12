using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IRCUT_FILTER_INFO_S
    {
        public Int32 udwIrCutFilterMode;                            /* 昼夜模式：0白天，1，夜晚，2自动 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;                                        /* Reserved */
    }

}
