using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENZOOM
    {
        public uint dwSize;
        public uint dwScreenNum;//大屏号
        public NET_DVR_POINT_FRAME struPointFrame;
        public byte byLayer;//图层号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
