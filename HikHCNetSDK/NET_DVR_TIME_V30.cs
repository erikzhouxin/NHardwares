using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //时间参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIME_V30
    {
        public ushort wYear;
        public byte byMonth;
        public byte byDay;
        public byte byHour;
        public byte byMinute;
        public byte bySecond;
        public byte byRes;
        public ushort wMilliSec;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }

}
