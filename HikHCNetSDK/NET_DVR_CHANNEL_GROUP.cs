using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANNEL_GROUP
    {
        public uint dwSize;//结构体大小 
        public uint dwChannel;//通道号 
        public uint dwGroup; //组号，从0开始，即0表示第1组，1表示第2组，依次类推 
        public byte byID;//设备区域设置ID 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwPositionNo;//场景位置索引号，IPC为0，IPD从1开始  
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 56, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
