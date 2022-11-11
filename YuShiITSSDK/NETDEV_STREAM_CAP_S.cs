using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 码流能力信息 Stream capability
     * @attention
     */
    public struct NETDEV_STREAM_CAP_S
    {
        public Int32 udwstreamID;                                                              /* 码流索引，参见枚举NETDEV_LIVE_STREAM_INDEX_E。Stream index. For enumeration, seeNETDEV_LIVE_STREAM_INDEX_E */
        public Int32 udwResolutionNum;                                                         /* 支持的分辨率个数 Number of resolution*/
        public Int32 udwFrameRateNum;                                                          /* 支持的帧率个数Number of frame rate*/
        public Int32 udwMaxFrameRate;                                                          /* 当前码流最大帧率 Number of frame rate*/
        public Int32 udwMaxMJPEGFrameRate;                                                     /* 当前码流MJPEG最大帧率 Maximum MJPEG frame rate of current stream*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public Int32[] audwFrameRateList;                                                      /* 支持的帧率数组  Frame rate array*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public NETDEV_RESOLUTION_CAPABILITY_S[] astResolutionCapabilityList;                  /*支持的分辨率列表 List of resolution*/
        public NETDEV_SMART_ENCODE_S stSmartEncode;                                           /*图像扩展编码模式 Smart image encoding mode*/
    }

}
