using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 视频流信息列表 Video stream list
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_LIST_S
    {
        public UInt32 udwNum;                                /* 视频流个数 Number of video stream */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_16)]
        public NETDEV_VIDEO_STREAM_INFO_EX_S astVideoStreamInfoList;/* 视频流信息列表 Video stream list*/
    }

}
