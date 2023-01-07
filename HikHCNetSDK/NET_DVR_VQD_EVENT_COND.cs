using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频质量诊断事件条件结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VQD_EVENT_COND
    {
        public uint dwChannel;   //通道号
        public uint dwEventType; //检测事件类型，参见VQD_EVENT_ENUM
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   //保留
    }
}
