using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISK_RAID_INFO
    {
        public uint dwSize;   //结构体大小
        public byte byEnable;  //磁盘Raid是否禁用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 35, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留字节
    }
}
