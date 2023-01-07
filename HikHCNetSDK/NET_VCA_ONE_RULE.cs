using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //警戒规则结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_ONE_RULE
    {
        public byte byActive;//是否激活规则,0-否,非0-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，设置为0字段
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;//规则名称
        public VCA_EVENT_TYPE dwEventType;//行为分析事件类型
        public NET_VCA_EVENT_UNION uEventParam;//行为分析事件参数
        public NET_VCA_SIZE_FILTER struSizeFilter;//尺寸过滤器
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;//处理方式 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;//报警触发的录象通道,为1表示触发该通道
    }

}
