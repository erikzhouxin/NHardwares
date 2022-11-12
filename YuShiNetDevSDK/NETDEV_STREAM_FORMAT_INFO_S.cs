using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STREAM_FORMAT_INFO_S
    {
        public UInt32 udwStreamIndex;             /* 视频流索引 参考 NETDEV_LIVE_STREAM_INDEX_E */
        public UInt32 udwEncodeFormat;            /* 编码格式 参考 NETDEV_VIDEO_CODE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
