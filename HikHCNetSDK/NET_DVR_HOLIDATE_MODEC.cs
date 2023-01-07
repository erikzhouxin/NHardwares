using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDATE_MODEC
    {
        public ushort wStartYear;       // 年
        public byte byStartMon;     // 月
        public byte byStartDay;     // 日
        public ushort wEndYear;     // 年
        public byte byEndMon;       // 月
        public byte byEndDay;       // 日
    }
}
