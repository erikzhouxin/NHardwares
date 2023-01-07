using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_VIDEOPLATFORM
    {
        /*各个子窗口对应解码通道所对应的解码子系统的槽位号(对于视频综合平台中解码子系统有效)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecoderId;
    }
}
