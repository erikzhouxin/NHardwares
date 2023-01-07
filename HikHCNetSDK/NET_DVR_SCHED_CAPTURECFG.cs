using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道抓图计划
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCHED_CAPTURECFG
    {
        public uint dwSize;     //结构体
        public byte byEnable;   //是否抓图
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;   //保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CAPTURE_DAY[] struCaptureDay;//全天抓图计划
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CAPTURE_SCHED[] struCaptureSched;//时间段抓图布防计划
        public NET_DVR_CAPTURE_DAY struCaptureHoliday;  //假日抓图计划
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CAPTURE_SCHED[] struHolidaySched;    //时间段假日抓图布防计划
        public uint dwRecorderDuration; //抓图保存最长时间 0xffffffff表示该值无效 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            //保留字节
    }
}
