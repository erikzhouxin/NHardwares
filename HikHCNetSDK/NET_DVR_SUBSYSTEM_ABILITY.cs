using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SUBSYSTEM_ABILITY
    {
        /*子系统类型，1-解码用子系统，2-编码用子系统，3-级联输出子系统，4-级联输入子系统，5-码分器子系统，6-报警主机子系统，7-智能子系统，8-V6解码子系统，9-V6子系统，0-NULL（此参数只能获取）*/
        public byte bySubSystemType;
        public byte byChanNum;//子系统通道数
        public byte byStartChan;//子系统起始通道数
        public byte bySlotNum;//槽位号 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public struDecoderSystemAbility _struAbility;
    }

}
