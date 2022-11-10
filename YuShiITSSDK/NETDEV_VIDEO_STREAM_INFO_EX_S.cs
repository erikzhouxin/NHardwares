using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 视频流信息(LAPI) Video stream info(LAPI)
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_EX_S
    {
        public string bEnabled;                                                                /* 视频流是否启用编码 Enable encoding for video stream or not*/
        public UInt32 udwStreamID;                                                             /* 码流索引，参见枚举NETDEV_LIVE_STREAM_INDEX_E  Stream index. For enumeration, seeNETDEV_LIVE_STREAM_INDEX_E*/
        public UInt32 udwMainStreamType;                                                       /* 主码流类型，参见NETDEV_MAIN_STREAM_TYPE_E  Main stream. See NETDEV_MAIN_STREAM_TYPE_E for reference */
        public NETDEV_VIDEO_ENCODE_INFO_S stVideoEncodeInfo;                                   /* 视频编码参数信息 Video encoding parameter*/
    }

}
