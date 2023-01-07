using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct STRUCT_ALARM_CHANNEL
    {
        public uint dwAlarmChanNum; /*发生报警通道数据个数，用于后面计算变长数据部分中所有发生的报警通道号，四字节表示一个*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
