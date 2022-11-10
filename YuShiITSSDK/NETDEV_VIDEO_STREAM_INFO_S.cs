using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 通道视频流信息 结构体定义 Channel video stream information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_S
    {
        public NETDEV_LIVE_STREAM_INDEX_E enStreamType;       /* 码流索引 Stream index */
        public Int32 bEnableFlag;        /* 是否启用 Enable or not */
        public Int32 dwHeight;           /* 视频编码分辨率-Height  Video encoding resolution - Height */
        public Int32 dwWidth;            /* 视频编码分辨率-Width  Video encoding resolution - Width */
        public Int32 dwFrameRate;        /* 视频编码配置帧率 Video encoding configuration frame rate */
        public Int32 dwBitRate;          /* 码率 Bit rate */
        public NETDEV_VIDEO_CODE_TYPE_E enCodeType;         /* 视频编码格式 Video encoding format */
        public NETDEV_VIDEO_QUALITY_E enQuality;          /* 图像质量 Image quality */
        public Int32 dwGop;              /* I帧间隔  I-frame interval */
        public Int32 bConstantBitRate;   /* 是否为定码率 0:变码率 1:定码率 Constant Bit Rate or Variable bit rate;0:Variable 1:Constant*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] byRes;                            /* Reserved */
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct NETDEV_VIDEO_STREAM_INFO_S
    //{
    //    public Int32 enStreamType;       /* NETDEV_LIVE_STREAM_INDEX_E*/
    //    public Int32 bEnableFlag;        
    //    public Int32 dwHeight;           /* -Height */
    //    public Int32 dwWidth;            /* -Width */
    //    public Int32 dwFrameRate;        
    //    public Int32 dwBitRate;          
    //    public Int32 enCodeType;         /* NETDEV_VIDEO_CODE_TYPE_E*/
    //    public Int32 enQuality;          /* UW_VIDEO_QUALITY_E*/
    //    public Int32 dwGop;              /* I */
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    //    public byte[] szReserve;
    //}
}
