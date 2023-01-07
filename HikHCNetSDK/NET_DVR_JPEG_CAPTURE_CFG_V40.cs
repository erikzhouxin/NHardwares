using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_JPEG_CAPTURE_CFG_V40
    {
        public uint dwSize;               //结构体长度
        public NET_DVR_TIMING_CAPTURE struTimingCapture;
        public NET_DVR_EVENT_CAPTURE_V40 struEventCapture;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;     // 保留字节
    }
}
