using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*解码器设备状态*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODER_WORK_STATUS_V41
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIX_CHAN_STATUS[] struDecChanStatus;     /*解码通道状态*/
        /*显示通道状态*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISPNUM_V41, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DISP_CHAN_STATUS_V41[] struDispChanStatus;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmInStatus;         /*报警输入状态*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmOutStatus;       /*报警输出状态*/
        public byte byAudioInChanStatus;          /*语音对讲状态*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
