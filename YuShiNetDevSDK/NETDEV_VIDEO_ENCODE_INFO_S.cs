using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_ENCODE_INFO_S
    {
        public string bEnableSVCMode;                        /* SVC配置,0：关闭,1：开启 SVC configuration. 0-Off, 1-On*/
        public UInt32 udwEncodeFormat;                     /* 视频编码格式信息，参见枚举NETDEV_VIDEO_CODE_TYPE_E。  Video Compression. For enumeration, seeNETDEV_VIDEO_CODE_TYPE_E*/
        public UInt32 udwWidth;                            /* 图像宽度 Image width*/
        public UInt32 udwHeight;                           /* 图像高度 Image height*/
        public UInt32 udwBitrate;                          /* 码率 Bit rate*/
        public UInt32 udwBitrateType;                      /* 码率类型，参见NETDEV_BIT_RATE_TYPE_E。 Bitrate type. See NETDEV_BIT_RATE_TYPE_E for reference */
        public UInt32 udwFrameRate;                        /* 帧率 Frame rate*/
        public UInt32 udwGopType;                          /* Gop模式,参见NETDEV_GOP_TYPE_E。 GOP mode. See NETDEV_GOP_TYPE_E for reference */
        public UInt32 udwIFrameInterval;                   /* I帧间隔，范围根据能力来定 I Frame Interval. The range depends on capability*/
        public UInt32 udwImageQuality;                     /* 图像质量，范围[1, 9]，9代表图像质量最高 Image quality, ranges from 1 to 9. 9 means the highest quality*/
        public UInt32 udwSmoothLevel;                      /* 码流平滑等级，范围[1,9]，1代表平滑级别最低 Smoothing level, ranges from 1 to 9. 1 means the lowest level*/
        public UInt32 udwSmartEncodeMode;                  /* 智能编码模式，参见NETDEV_SMART_ENCODE_MODE_E。 Smart encoding mode. See NETDEV_SMART_ENCODE_MODE_E for reference*/
    }

}
