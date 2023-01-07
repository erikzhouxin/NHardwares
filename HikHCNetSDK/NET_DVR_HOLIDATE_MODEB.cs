using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDATE_MODEB
    {
        public byte byStartMonth;   // 从1开始
        public byte byStartWeekNum; // 第几个星期 从1开始 
        public byte byStartWeekday; // 星期几
        public byte byEndMonth;     // 从1开始
        public byte byEndWeekNum;   // 第几个星期 从1开始 
        public byte byEndWeekday;   // 星期几
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节 
    }
}
