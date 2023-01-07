using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMMODECFG
    {
        public uint dwSize;
        public byte byAlarmMode;//报警触发类型，1-轮询，2-保持 
        public ushort wLoopTime;//轮询时间, 单位：秒 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
