using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmLogSnapImage
     * @brief 抓拍图片信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_SNAP_IMAGE_S
    {
        public NETDEV_FILE_INFO_S stBigImage;                /* 大图 */
        public NETDEV_FILE_INFO_S stSmallImage;              /* 小图 */
        public NETDEV_FACE_ALARM_IMAGE_AREA_S stArea;        /* 区域坐标 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                            /* 保留字段  Reserved */
    }

}
