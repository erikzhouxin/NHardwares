using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECTCFG_EX
    {
        public uint dwXCoordinate;
        public uint dwYCoordinate;
        public uint dwWidth;
        public uint dwHeight;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
