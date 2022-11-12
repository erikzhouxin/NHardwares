using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_STREAM_INFO_S
    {
        public NETDEV_LIVE_STREAM_INDEX_E enStreamType;       /* Stream index */
        public Int32 bEnableFlag;        /* Enable or not */
        public Int32 dwHeight;           /* -Height  Video encoding resolution - Height */
        public Int32 dwWidth;            /* -Width  Video encoding resolution - Width */
        public Int32 dwFrameRate;        /* Video encoding configuration frame rate */
        public Int32 dwBitRate;          /* Bit rate */
        public NETDEV_VIDEO_CODE_TYPE_E enCodeType;         /* Video encoding format */
        public NETDEV_VIDEO_QUALITY_E enQuality;          /* Image quality */
        public Int32 dwGop;              /* I  I-frame interval */
        public Int32 bConstantBitRate;   /* Constant Bit Rate or Variable bit rate;0:Variable 1:Constant*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
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
