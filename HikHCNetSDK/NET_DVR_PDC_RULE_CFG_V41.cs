using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_RULE_CFG_V41
    {
        public uint dwSize;              //结构大小
        public byte byEnable;             // 是否激活规则;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       // 保留字节 
        public NET_VCA_POLYGON struPolygon;            // 多边形
        public NET_DVR_PDC_ENTER_DIRECTION struEnterDirection;    // 流量进入方向
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME struAlarmTime;//布防时间
        public NET_DVR_TIME_EX struDayStartTime; //白天开始时间，时分秒有效
        public NET_DVR_TIME_EX struNightStartTime; //夜晚开始时间，时分秒有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;       // 保留字节
    }


}
