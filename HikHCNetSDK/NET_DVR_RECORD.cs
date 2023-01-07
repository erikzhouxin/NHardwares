using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道录像参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORD
    {
        public uint dwSize;
        public uint dwRecord;/*是否录像 0-否 1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_RECORDDAY[] struRecAllDay;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_RECORDSCHED[] struRecordSched;
        public uint dwRecordTime;/* 录象时间长度 */
        public uint dwPreRecordTime;/* 预录时间 0-不预录 1-5秒 2-10秒 3-15秒 4-20秒 5-25秒 6-30秒 7-0xffffffff(尽可能预录) */
    }
}
