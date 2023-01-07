using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINFO_V40
    {
        public NET_DVR_ALRAM_FIXED_HEADER struAlarmFixedHeader; //报警固定部分
        public IntPtr pAlarmData;   //报警可变部分内容
    }

}
