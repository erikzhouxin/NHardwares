using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输入参数配置(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINCFG_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sAlarmInName;/* 名称 */
        public byte byAlarmType; //报警器类型,0：常开,1：常闭
        public byte byAlarmInHandle; /* 是否处理 0-不处理 1-处理*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_HANDLEEXCEPTION_V30 struAlarmHandleType;/* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;//报警触发的录象通道,为1表示触发该通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byEnablePreset;/* 是否调用预置点 0-否,1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byPresetNo;/* 调用的云台预置点序号,一个报警输入可以调用多个通道的云台预置点, 0xff表示不调用预置点。*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 192, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;/*保留*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byEnableCruise;/* 是否调用巡航 0-否,1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byCruiseNo;/* 巡航 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byEnablePtzTrack;/* 是否调用轨迹 0-否,1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byPTZTrack;/* 调用的云台的轨迹序号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }

}
