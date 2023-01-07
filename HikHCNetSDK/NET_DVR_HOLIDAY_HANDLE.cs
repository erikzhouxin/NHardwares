using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //假日报警处理方式
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDAY_HANDLE
    {
        public uint dwSize;             // 结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;   // 布防时间段
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 240, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;       // 保留字节
    }
}
