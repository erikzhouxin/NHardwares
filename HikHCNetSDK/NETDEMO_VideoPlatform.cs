using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct VideoPlatform
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecoderId;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byDecResolution;
        public NET_DVR_RECTCFG struPosition; //显示通道在电视墙中位置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 80, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
