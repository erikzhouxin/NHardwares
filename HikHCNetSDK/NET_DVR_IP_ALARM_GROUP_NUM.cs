using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IP_ALARM_GROUP_NUM
    {
        public uint dwSize;
        public uint dwIPAlarmInGroup;      //IP通道报警输入组数
        public uint dwIPAlarmInNum;       //IP通道报警输入个数
        public uint dwIPAlarmOutGroup;     //IP通道报警输出组数
        public uint dwIPAlarmOutNum;      //IP通道报警输出个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
