using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUDIOEXCEPTION_ALARM
    {
        public uint dwSize;     /*结构长度*/
        public byte byAlarmType;//报警类型，1-音频输入异常，2-音频输入突变
        public byte byRes1;
        public ushort wAudioDecibel;//声音强度（音频输入突变时用到）
        public NET_VCA_DEV_INFO struDevInfo;/*设备信息*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }
}
