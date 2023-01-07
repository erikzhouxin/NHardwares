using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISP_CHAN_STATUS
    {
        public byte byDispStatus;/*显示状态：0：未显示，1：启动显示*/
        public byte byBVGA; /*VGA/BNC*/
        public byte byVideoFormat;/*视频制式:1:NTSC,2:PAL,0-NON*/
        public byte byWindowMode;/*当前画面模式*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;/*各个子窗口关联的解码通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_DVR_MAX_DISPREGION, ArraySubType = UnmanagedType.I1)]
        public byte[] byFpsDisp;/*每个子画面的显示帧率*/
        public byte byScreenMode;           //屏幕模式0-普通 1-大屏
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
