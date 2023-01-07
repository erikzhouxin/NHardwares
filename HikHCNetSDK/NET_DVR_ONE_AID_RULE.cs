using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单条交通事件规则结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_AID_RULE
    {
        public byte byEnable;                   // 是否启用事件规则
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;                  // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;       // 规则名称 
        public uint dwEventType;                // 交通事件检测类型 TRAFFIC_AID_TYPE
        public NET_VCA_SIZE_FILTER struSizeFilter; // 尺寸过滤器
        public NET_VCA_POLYGON struPolygon;    // 规则区域
        public NET_DVR_AID_PARAM struAIDParam;   //  事件参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;    //处理方式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;        //报警触发的录象通道,为1表示触发该通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }



}
