using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SYSTEM_TIME
    {
        public ushort wYear;           //年
        public ushort wMonth;          //月
        public ushort wDay;            //日
        public ushort wHour;           //时
        public ushort wMinute;      //分
        public ushort wSecond;      //秒
        public ushort wMilliSec;    //毫秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
