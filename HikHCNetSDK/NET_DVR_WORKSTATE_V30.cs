using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR工作状态(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WORKSTATE_V30
    {
        public uint dwDeviceStatic;//设备的状态,0-正常,1-CPU占用率太高,超过85%,2-硬件错误,例如串口死掉
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISKSTATE[] struHardDiskStatic;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CHANNELSTATE_V30[] struChanStatic;//通道的状态
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmInStatic;//报警端口的状态,0-没有报警,1-有报警
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmOutStatic;//报警输出端口的状态,0-没有输出,1-有报警输出
        public uint dwLocalDisplay;//本地显示状态,0-正常,1-不正常
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AUDIO_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAudioChanStatus;//表示语音通道的状态 0-未使用，1-使用中, 0xff无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            struHardDiskStatic = new NET_DVR_DISKSTATE[HikHCNetSdk.MAX_DISKNUM_V30];
            struChanStatic = new NET_DVR_CHANNELSTATE_V30[HikHCNetSdk.MAX_CHANNUM_V30];
            for (int i = 0; i < HikHCNetSdk.MAX_CHANNUM_V30; i++)
            {
                struChanStatic[i].Init();
            }
            byAlarmInStatic = new byte[HikHCNetSdk.MAX_ALARMOUT_V30];
            byAlarmOutStatic = new byte[HikHCNetSdk.MAX_ALARMOUT_V30];
            byAudioChanStatus = new byte[HikHCNetSdk.MAX_AUDIO_V30];
            byRes = new byte[10];
        }
    }

}
