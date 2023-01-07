using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //时间段(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCHEDTIME
    {
        public byte byStartHour;//开始时间
        public byte byStartMin;//开始时间
        public byte byStopHour;//结束时间
        public byte byStopMin;//结束时间
    }

}
