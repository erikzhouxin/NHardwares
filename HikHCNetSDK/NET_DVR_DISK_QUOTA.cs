using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //磁盘配额
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISK_QUOTA
    {
        public byte byQuotaType;     // 磁盘配额类型,1 - 按容量 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       // 保留字节
        public uint dwHCapacity;     // 分配的磁盘容量高32位 单位MB
        public uint dwLCapacity;     // 分配的磁盘容量低32位 单位MB
        public uint dwHUsedSpace;    // 已使用的磁盘大小高32位 单位MB
        public uint dwLUsedSpace;    // 已使用的磁盘大小低32位 单位MB
        public byte byQuotaRatio;    //	分配的磁盘比例,单位:%
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;      // 保留字节
    }
}
