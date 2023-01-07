using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*解码器设备状态*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISP_CHAN_STATUS_V41
    {
        public byte byDispStatus;      /*显示状态：0：未显示，1：启动显示*/
        public byte byBVGA;              /*0-BNC，1-VGA， 2-HDMI，3-DVI，0xff-无效*/
        public byte byVideoFormat;     /*视频制式，1:NTSC,2:PAL,0-NON*/
        public byte byWindowMode;       /*画面模式*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;   /*各个子画面关联的解码通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byFpsDisp;        /*每个子画面的显示帧率*/
        public byte byScreenMode;       /*屏幕模式0-普通 1-大屏*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwDispChan; /*获取全部显示通道状态时有效，设置时可填0*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
