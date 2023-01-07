using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INTRUSION_SEARCHCOND
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTRUSIONREGION_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_INTRUSION[] struVcaIntrusion; //入侵区域
        public uint dwPreTime;   /*智能报警提前时间 单位:秒*/
        public uint dwDelayTime; /*智能报警延迟时间 单位:秒*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5400, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
