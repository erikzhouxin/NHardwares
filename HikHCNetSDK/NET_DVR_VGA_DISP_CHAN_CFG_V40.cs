using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VGA_DISP_CHAN_CFG_V40
    {
        public uint dwSize;
        public byte byAudio;            /*音频是否开启*/
        public byte byAudioWindowIdx;      /*音频开启子窗口*/
        public byte byVgaResolution;      /*分辨率，从能力集获取*/
        public byte byVedioFormat;         /*1:NTSC,2:PAL，0-NULL*/
        public uint dwWindowMode;       /*画面模式，能力集获取*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;/*各个子窗口关联的解码通道*/
        public byte byEnlargeStatus;          /*是否处于放大状态，0：不放大，1：放大*/
        public byte byEnlargeSubWindowIndex;//放大的子窗口号
        public byte byScale; /*显示模式，0---真实显示，1---缩放显示( 针对BNC )*/
        /*区分共用体，0-视频综合平台内部解码器显示通道配置，1-其他解码器显示通道配置*/
        public byte byUnionType;

        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct struDiff
        {
            [FieldOffsetAttribute(0)]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 160, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            /*[FieldOffsetAttribute(0)]
            public UNION_VIDEOPLATFORM_V40 struVideoPlatform;

            [FieldOffsetAttribute(0)]
            public UNION_NOTVIDEOPLATFORM_V40 struNotVideoPlatform;
             * */
        }
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
