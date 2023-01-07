using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //简化的规则信息, 包含规则的基本信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RULE_INFO
    {
        public byte byRuleID;//规则ID,0-7
        public byte byRes;//保留
        public ushort wEventTypeEx;   //行为事件类型扩展，用于代替字段dwEventType，参考VCA_RULE_EVENT_TYPE_EX
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;//规则名称
        public VCA_EVENT_TYPE dwEventType;//警戒事件类型
        public NET_VCA_EVENT_UNION uEventParam;//事件参数
    }
}
