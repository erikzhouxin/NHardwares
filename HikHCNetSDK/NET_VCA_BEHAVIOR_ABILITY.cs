using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为能力集结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BEHAVIOR_ABILITY
    {
        public uint dwSize;//结构长度
        public uint dwAbilityType;//支持的能力类型，按位表示，见VCA_ABILITY_TYPE定义
        public byte byMaxRuleNum;//最大规则数
        public byte byMaxTargetNum;//最大目标数
        public byte bySupport;      // 支持的功能类型   按位表示  
                                    // bySupport & 0x01 支持标定功能
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留，设置为0
    }

}
