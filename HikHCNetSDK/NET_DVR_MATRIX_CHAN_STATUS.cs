using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*解码通道状态*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_CHAN_STATUS
    {
        public byte byDecodeStatus;/*当前状态:0:未启动，1：启动解码*/
        public byte byStreamType;/*码流类型*/
        public byte byPacketType;/*打包方式*/
        public byte byRecvBufUsage;/*接收缓冲使用率*/
        public byte byDecBufUsage;/*解码缓冲使用率*/
        public byte byFpsDecV;/*视频解码帧率*/
        public byte byFpsDecA;/*音频解码帧率*/
        public byte byCpuLoad;/*DSP CPU使用率*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwDecodedV;/*解码的视频帧*/
        public uint dwDecodedA;/*解码的音频帧*/
        public ushort wImgW;/*解码器当前的图像大小,宽*/
        public ushort wImgH; //高
        public byte byVideoFormat;/*视频制式:0-NON,NTSC--1,PAL--2*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public uint dwDecChan; /*获取全部解码通道状态时有效，设置时可填0*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
