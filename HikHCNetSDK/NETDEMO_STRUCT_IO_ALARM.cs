using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct STRUCT_IO_ALARM
    {
        public uint dwAlarmInputNo;     //发生报警的报警输入通道号，一次只有一个
        public uint dwTrigerAlarmOutNum;    /*触发的报警输出个数，用于后面计算变长数据部分中所有触发的报警输出通道号，四字节表示一个*/
        public uint dwTrigerRecordChanNum;  /*触发的录像通道个数，用于后面计算变长数据部分中所有触发的录像通道号，四字节表示一个*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 116, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
