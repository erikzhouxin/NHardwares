using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUDIO_EXCEPTION
    {
        public uint dwSize;
        public byte byEnableAudioInException;  //使能，是否开启
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_VCA_AUDIO_ABNORMAL struAudioAbnormal;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmSched; //布防时间
        public NET_DVR_HANDLEEXCEPTION_V40 struHandleException;  //异常处理方式
        public uint dwMaxRelRecordChanNum;  //报警触发的录象通道 数（只读）最大支持数量
        public uint dwRelRecordChanNum;     //报警触发的录象通道 数 实际支持的数量
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] byRelRecordChan;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
