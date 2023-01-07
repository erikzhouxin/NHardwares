using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //警戒规则结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_ONE_RULE_V41
    {
        public byte byActive; //是否激活规则,0-否,非0-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  //保留，设置为0字段
        public ushort wEventTypeEx; //行为事件类型扩展，用于代替字段dwEventType，参考VCA_RULE_EVENT_TYPE_EX
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName; //规则名称
        public uint dwEventType;    //行为事件类型，保留是为了兼容，后续建议使用wEventTypeEx获取事件类型
        public NET_VCA_EVENT_UNION uEventParam; //行为分析事件参数
        public NET_VCA_SIZE_FILTER struSizeFilter;  //尺寸过滤器
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;  //处理方式 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan; //报警触发的录象通道,为1表示触发该通道
        public ushort wAlarmDelay; //智能报警延时，0-5s,1-10,2-30s,3-60s,4-120s,5-300s,6-600s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
        public NET_VCA_FILTER_STRATEGY struFilterStrategy; //尺寸过滤策略
        public NET_VCA_RULE_TRIGGER_PARAM struTriggerParam;   //规则触发参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
