using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //目前只有有人无人事件和人员聚集事件实时报警上传
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EVENT_INFO
    {
        public byte byRuleID;               // Rule ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;   // 规则名称
        public uint dwEventType;            // 参照VCA_EVENT_TYPE
        public NET_DVR_EVENT_PARAM_UNION uEventParam;  // 
    }



}
