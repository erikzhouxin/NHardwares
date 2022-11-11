using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 视频输入通道的视频能力集 Encoding parameter capability
     * @attention
     */
    public struct NETDEV_VIDEO_STREAM_CAP_EX_S
    {
        public Int32 bIsSupportCfg;                                                             /* 是否支持配置,0: 不支持, 1: 支持 Support configuration or not. 0-No, 1-Yes*/
        public Int32 bIsSupportSmoothLevel;                                                     /* 是否支持码流平滑,0: 不支持, 1: 支持 Support smoothing or not. 0-No, 1-Yes*/
        public Int32 bIsSupportImageFormat;                                                     /* 图像制式是否可配,0: 不支持, 1: 支持 Support configuration of image mode or not. 0-No, 1-Yes*/
        public Int32 udwEncodeFormatNum;                                                        /*  支持的视频编码格式个数 Number of video compression*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_ENCODE_FORMAT_MAX_NUM)]
        public Int32[] audwEncodeFormatList;                      /*  支持的视频编码格式列表，参见NETDEV_VIDEO_CODE_TYPE_E。 Video compression list. See NETDEV_VIDEO_CODE_TYPE_E for reference */
        public Int32 udwMinIFrameInterval;                                                    /* 支持的I帧间隔最小值 Minimum value of I Frame Interval*/
        public Int32 udwMaxIFrameInterval;                                                    /* 支持的I帧间隔最大值 Maximum value of I Frame Interval*/
        public Int32 udwGOPTypeNum;                                                           /* 支持的GOP类型数量  Number of GOP type*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_GOP_TYPE_MAX_NUM)]
        public Int32[] audwGOPTypeList;                                /* 支持的GOP类型列表 List of GOP type*/
        public Int32 udwVideoModeNum;                                                         /*支持的视频制式个数  Number of video mode*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public NETDEV_VIDEO_MODE_INFO_S[] astVideoModeList;                       /* 视频制式能力列表 List of video mode capability*/
        public Int32 udwStreamCapNum;                                                         /*支持的码流个数 Number of stream*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        NETDEV_STREAM_CAP_S[] astStreamCapList;                            /*支持的码流能力列表 List of stream capability*/
        public Int32 bIsSupportScrambled;                                  /* 是否支持码流加扰，0: 不支持, 1: 支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                               /* 保留字段 */
    }

}
