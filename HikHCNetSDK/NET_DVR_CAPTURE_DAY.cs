using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAPTURE_DAY
    {
        public byte byAllDayCapture;    // 是否全天抓图
        public byte byCaptureType;      // 抓图类型：0-定时抓图，1-移动侦测抓图，2-报警抓图，3-移动侦测或报警抓图，4-移动侦测和报警抓图，6-智能报警抓图
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
