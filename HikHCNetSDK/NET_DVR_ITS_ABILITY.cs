using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 交通能力集结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ITS_ABILITY
    {
        public uint dwSize;             // 结构体大小
        public uint dwAbilityType;      // 支持的能力列表  参照ITS_ABILITY_TYPE
        public byte byMaxRuleNum;       //最大规则数
        public byte byMaxTargetNum;     //最大目标数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            // 保留
    }

}
