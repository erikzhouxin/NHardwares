using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 分析仪规则结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_RULECFG
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_IVMS_ONE_RULE[] struRule; //规则数组
    }
}
