using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S
    {
        public Int32 udwFaceId;                                         /* 人脸ID */
        public IntPtr pcPicBuff;                                        /* 图片缓存，Base64编码(使用完后需在SDK内部free) */
        public Int32 udwPicBuffLen;                                     /* 图片缓存长度 */
        public Int32 enImgType;                                         /* 图像类型，参考枚举NETDEV_TMS_PERSION_IMAGE_TYPE_E */
        public Int32 enImgFormat;                                       /* 图像格式，参考枚举NETDEV_TMS_PERSION_IMAGE_FORMAT_E */
        NETDEV_FACE_POSITION_INFO_S stFacePos;                          /* 人脸坐标---画面坐标归一化：0-10000 ;  矩形左上和右下点："138,315,282,684" */
        public Int32 udwImageWidth;                                     /* 图像宽度 */
        public Int32 udwImageHeight;                                    /* 图像高度 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_CAMER_ID_LEN)]
        public char[] szCamerID;                                        /* 相机编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_FACE_RECORD_ID_LEN)]
        public char[] szRecordID;                                       /* 记录ID号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_FACE_TOLLGATE_ID_LEN)]
        public char[] szTollgateID;                                     /* 卡口编号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TMS_PASSTIME_LEN)]
        public char[] szPassTime;                                       /* 经过时刻,YYYYMMDDHHMMSSMMM，时间按24小时制。第一组MM表示月，第二组MM表示分，第三组MMM表示毫秒 */
        public UInt32 udwFaceNum;                                     /* 人脸个数 全景图时有效*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_IPV4_LEN_MAX)]
        public byte[] szIPAddr;                                       /* 设备IP地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 76)]
        public byte[] byRes;                                            /*   Reserved field*/
    };

}
