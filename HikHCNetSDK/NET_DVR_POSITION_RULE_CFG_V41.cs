using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POSITION_RULE_CFG_V41
    {
        public uint dwSize;             // 结构大小 
        public NET_DVR_PTZ_POSITION struPtzPosition;    // 场景位置信息
        public NET_VCA_RULECFG_V41 struVcaRuleCfg;     //行为规则配置
        public byte byTrackEnable; //是否启用跟踪
        public byte byRes1;
        public ushort wTrackDuration; //跟踪持续时间，单位s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 76, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;         // 保留字节
    }


}
