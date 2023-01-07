using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //校时结构参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIME
    {
        public int dwYear;
        public int dwMonth;
        public int dwDay;
        public int dwHour;
        public int dwMinute;
        public int dwSecond;
    }

}
