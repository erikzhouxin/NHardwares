using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVStructImageInfo
     * @brief 图像相关信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_IMAGE_INFO_S
    {
        public UInt32 udwIndex;                                      /* 图像索引 */
        public UInt32 udwType;                                       /* 图像类型 */
        public UInt32 udwFormat;                                     /* 图像格式 详见 NETDEV_IMAGE_FORMAT_E*/
        public UInt32 udwWidth;                                      /* 图像的宽度 */
        public UInt32 udwHeight;                                     /* 图像的高度 */
        public UInt32 udwCaptureTime;                                /* 图片采集时刻 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szUrl;                         /* 图片URL */
        public UInt32 udwSize;                                       /* 图像经过base64编码之后的长度 最大3M */
        public IntPtr pszData;                                       /* 图像的base64编码数据(CHAR*) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
