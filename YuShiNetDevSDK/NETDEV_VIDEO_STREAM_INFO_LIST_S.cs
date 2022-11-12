using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_LIST_S
    {
        public UInt32 udwNum;                                /* Number of video stream */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_VIDEO_STREAM_INFO_EX_S astVideoStreamInfoList;/* Video stream list*/
    }

}
