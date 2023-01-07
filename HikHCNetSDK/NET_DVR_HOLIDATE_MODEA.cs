using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //模式A 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDATE_MODEA
    {
        public byte byStartMonth;   // 开始月 从1开始
        public byte byStartDay;     // 开始日 从1开始
        public byte byEndMonth;     // 结束月 
        public byte byEndDay;       // 结束日
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }
}
