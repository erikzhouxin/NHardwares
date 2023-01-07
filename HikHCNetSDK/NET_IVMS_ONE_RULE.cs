using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //分析仪行为分析规则结构
    //警戒规则结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_ONE_RULE
    {
        public byte byActive;/* 是否激活规则,0-否, 非0-是 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留，设置为0字段
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;//规则名称
        public VCA_EVENT_TYPE dwEventType;//行为分析事件类型
        public NET_VCA_EVENT_UNION uEventParam;//行为分析事件参数
        public NET_VCA_SIZE_FILTER struSizeFilter;//尺寸过滤器
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;/*保留，设置为0*/
    }
}
