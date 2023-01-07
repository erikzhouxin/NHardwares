using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通参数统计规则配置结构体(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_RULECFG_V41
    {
        public uint dwSize;         // 结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TPS_RULE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_TPS_RULE_V41[] struOneTpsRule; // 下标对应交通参数ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     // 保留
    }



}
