using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POSITION_RULE_CFG
    {
        public uint dwSize;             // 结构大小 
        public NET_DVR_PTZ_POSITION struPtzPosition;    // 场景位置信息
        public NET_VCA_RULECFG struVcaRuleCfg;     //行为规则配置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 80, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;         // 保留字节
    }


}
