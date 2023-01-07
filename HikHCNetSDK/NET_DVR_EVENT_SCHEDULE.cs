using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    public struct NET_DVR_EVENT_SCHEDULE
    {
        public uint dwSize;//结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime; /*布防时间*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struHolidayAlarmTime; /*假日布防时间*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] bySceneID;//场景号,目前支持1~4场景，0为无效。该场景号与布防时间中每个时间段一一对应。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 72, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
