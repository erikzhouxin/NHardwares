using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_SCHEDULE_DAYTIME
    {
        public NET_DVR_DAYTIME struStartTime; //开始时间
        public NET_DVR_DAYTIME struStopTime; //结束时间
    }
}
