using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
 * @enum tagNETDEVCFGCmd
 * @brief   Parameter configuration command words Enumeration definition
 * @attention  None
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARSE_VIDEO_DATA_S
    {
        public byte pucData;             /* Pointer to video data */
        public Int32 dwDataLen;            /* Video data length */
        public Int32 dwVideoFrameType;     /* NETDEV_VIDEO_FRAME_TYPE_E  Frame type, see enumeration #NETDEV_VIDEO_FRAME_TYPE_E */
        public Int32 dwVideoCodeFormat;    /* #NETDEV_VIDEO_CODE_TYPE_E  Video encoding format, see enumeration #NETDEV_VIDEO_CODE_TYPE_E */
        public Int32 dwHeight;             /* Video image height */
        public Int32 dwWidth;              /* Video image width */
        public Int64 tTimeStamp;           /* Time stamp (ms) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byRes;              /* Reserved field*/
    };

}
