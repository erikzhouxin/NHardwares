using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct STRUCT_ALARM_HD
    {
        public uint dwAlarmHardDiskNum; /*发生报警的硬盘数据长度，用于后面计算变长数据部分中所有发生报警的硬盘号，四节表示一个*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
