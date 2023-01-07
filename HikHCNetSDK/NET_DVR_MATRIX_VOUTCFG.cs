using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*显示通道配置结构体*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_VOUTCFG
    {
        public uint dwSize;
        public byte byAudio;            /*音频是否开启*/
        public byte byAudioWindowIdx;      /*音频开启子窗口*/
        public byte byDispChanType;      /*显示通道类型：0-BNC，1-VGA，2-HDMI，3-DVI，4-YPbPr(解码卡服务器DECODER_SERVER专用)*/
        public byte byVedioFormat;         /*1:NTSC,2:PAL，0-NULL*/
        public uint dwResolution;//分辨率
        public uint dwWindowMode;       /*画面模式，能力集获取*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;/*各个子窗口关联的解码通道,设备支持解码资源自动分配时此参数不用填充*/
        public byte byEnlargeStatus;          /*是否处于放大状态，0：不放大，1：放大*/
        public byte byEnlargeSubWindowIndex;//放大的子窗口号
        public byte byScale; /*显示模式，0---真实显示，1---缩放显示( 针对BNC )*/
        public byte byUnionType;/*区分共用体,0-视频综合平台内部解码器显示通道配置，1-其他解码器显示通道配置*/
        public NET_DVR_VIDEO_PLATFORM struDiff;
        public uint dwDispChanNum; //显示输出号，此参数在全部获取时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 76, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
