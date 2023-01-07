using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析结果 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_VCA_RET
    {
        public uint dwChanNo;//触发事件的通道号
        public byte byRuleID;//规则ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;//规则名称
        public NET_VCA_EVENT_UNION uEvent;//行为事件参数，wMinorType = VCA_EVENT_TYPE决定事件类型

        public void Init()
        {
            byRes1 = new byte[3];
            byRuleName = new byte[HikHCNetSdk.NAME_LEN];
        }
    }


}
