using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAPTURE_SCHED
    {
        public NET_DVR_SCHEDTIME struCaptureTime;        // 抓图时间段
        public byte byCaptureType;       // 抓图类型：0-定时抓图，1-移动侦测抓图，2-报警抓图，3-移动侦测或报警抓图，4-移动侦测和报警抓图，6-智能报警抓图
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           // 保留字节
    }
}
