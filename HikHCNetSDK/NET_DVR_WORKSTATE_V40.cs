using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备工作状态扩展结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WORKSTATE_V40
    {
        public uint dwSize;            //结构体大小
        public uint dwDeviceStatic;      //设备的状态,0-正常,1-CPU占用率太高,超过85%,2-硬件错误,例如串口死掉
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISKSTATE[] struHardDiskStatic;   //硬盘状态,一次最多只能获取33个硬盘信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CHANNELSTATE_V30[] struChanStatic;//通道的状态，从前往后顺序排列
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwHasAlarmInStatic; //有报警的报警输入口，按值表示，按下标值顺序排列，值为0xffffffff时当前及后续值无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwHasAlarmOutStatic; //有报警输出的报警输出口，按值表示，按下标值顺序排列，值为0xffffffff时当前及后续值无效
        public uint dwLocalDisplay;         //本地显示状态,0-正常,1-不正常
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AUDIO_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAudioInChanStatus;      //按位表示语音通道的状态 0-未使用，1-使用中，第0位表示第1个语音通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                //保留
    }

}
