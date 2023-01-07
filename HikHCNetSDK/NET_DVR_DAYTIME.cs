using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DAYTIME
    {
        public byte byHour;//0~24
        public byte byMinute;//0~60
        public byte bySecond;//0~60
        public byte byRes;
        public ushort wMilliSecond; //0~1000
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
