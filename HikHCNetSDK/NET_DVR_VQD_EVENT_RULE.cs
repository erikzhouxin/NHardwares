using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频质量诊断事件规则
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VQD_EVENT_RULE
    {
        public uint dwSize;       //结构体大小 
        public byte byEnable;     //0-不启用，1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    //保留
        public NET_DVR_VQD_EVENT_PARAM struEventParam; //视频质量诊断事件参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//检测时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;  //处理方式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IVMS_IP_CHANNEL, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan; //报警触发的录象通道：1表示触发该通道；0表示不触发
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;    //保留
    }
}
