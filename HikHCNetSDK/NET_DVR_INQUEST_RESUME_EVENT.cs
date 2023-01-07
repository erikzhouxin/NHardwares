using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_RESUME_EVENT
    {
        public uint dwResumeNum;       //需恢复的事件个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RESUME_SEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_INQUEST_RESUME_SEGMENT[] struResumeSegment;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留
    }
}
