using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STREAM_FORMAT_INFO_S
    {
        public UInt32 udwStreamIndex;             /* See NETDEV_LIVE_STREAM_INDEX_E */
        public UInt32 udwEncodeFormat;            /* See NETDEV_VIDEO_CODE_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
