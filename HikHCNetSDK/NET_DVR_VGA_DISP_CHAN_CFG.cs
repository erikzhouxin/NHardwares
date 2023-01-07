using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VGA_DISP_CHAN_CFG
    {
        public uint dwSize;
        public byte byAudio;/*音频是否开启,0-否，1-是*/
        public byte byAudioWindowIdx;/*音频开启子窗口*/
        public byte byVgaResolution;/*VGA的分辨率*/
        public byte byVedioFormat;/*视频制式，1:NTSC,2:PAL,0-NON*/
        public uint dwWindowMode;/*画面模式，从能力集里获取，目前支持1,2,4,9,16*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;/*各个子窗口关联的解码通道*/
        public byte byEnlargeStatus;          /*是否处于放大状态，0：不放大，1：放大*/
        public byte byEnlargeSubWindowIndex;//放大的子窗口号
        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct struDiff
        {
            [FieldOffsetAttribute(0)]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }
        public byte byUnionType;/*区分共用体，0-视频综合平台内部解码器显示通道配置，1-其他解码器显示通道配置*/
        public byte byScale; /*显示模式，0---真实显示，1---缩放显示( 针对BNC )*/
    }
}
