using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //模拟报警输入参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ANALOG_ALARMINCFG
    {
        public uint dwSize;
        public byte byEnableAlarmHandle; //处理报警输入
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmInName; //模拟报警输入名称
        public ushort wAlarmInUpper; //模拟输入电压上限，实际值乘10，范围0~360
        public ushort wAlarmInLower; //模拟输入电压下限，实际值乘10，范围0~360 
        public NET_DVR_HANDLEEXCEPTION_V30 struAlarmHandleType; /* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan; //被触发的录像通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
