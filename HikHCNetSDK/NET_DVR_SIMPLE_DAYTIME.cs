using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SIMPLE_DAYTIME
    {
        public byte byHour; //hour
        public byte byMinute; //minute
        public byte bySecond; //second
        public byte byRes;
    }

}
