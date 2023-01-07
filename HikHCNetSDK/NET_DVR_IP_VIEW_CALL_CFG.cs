using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IP分机呼叫对讲参数配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_IP_VIEW_CALL_CFG
    {
        public uint dwSize;
        public byte byEnableAutoResponse; //使能自动应答,0-不使能，1-使能
        public byte byAudoResponseTime; //自动应答时间，0-30秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byEnableAlarmNumber1; //启动报警号码1，0-不启动，1-启动
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NUMBER_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmNumber1; //呼叫号码1
        public byte byEnableAlarmNumber2; //启动报警号码2，0-不启动，1-启动
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NUMBER_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmNumber2; //呼叫号码2，呼叫号码1失败会尝试呼叫号码2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 72, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes4;
    }
}
