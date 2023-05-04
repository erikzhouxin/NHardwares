using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// DVR工作状态
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WORKSTATE
    {
        /// <summary>
        /// 设备的状态,0-正常,1-CPU占用率太高,超过85%,2-硬件错误,例如串口死掉
        /// </summary>
        public uint dwDeviceStatic;
        /// <summary>
        /// 硬盘状态
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISKSTATE[] struHardDiskStatic;
        /// <summary>
        /// 通道的状态
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CHANNELSTATE[] struChanStatic;
        /// <summary>
        /// 报警端口的状态,0-没有报警,1-有报警
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmInStatic;
        /// <summary>
        /// 报警输出端口的状态,0-没有输出,1-有报警输出
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmOutStatic;
        /// <summary>
        /// 本地显示状态,0-正常,1-不正常
        /// </summary>
        public uint dwLocalDisplay;
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            struHardDiskStatic = new NET_DVR_DISKSTATE[HikHCNetSdk.MAX_DISKNUM];
            struChanStatic = new NET_DVR_CHANNELSTATE[HikHCNetSdk.MAX_CHANNUM];
            byAlarmInStatic = new byte[HikHCNetSdk.MAX_ALARMIN];
            byAlarmOutStatic = new byte[HikHCNetSdk.MAX_ALARMOUT];
        }
    }

}
