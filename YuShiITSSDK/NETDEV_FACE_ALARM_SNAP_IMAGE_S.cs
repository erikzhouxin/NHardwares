using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmLogSnapImage
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_SNAP_IMAGE_S
    {
        public NETDEV_FILE_INFO_S stBigImage;
        public NETDEV_FILE_INFO_S stSmallImage;
        public NETDEV_FACE_ALARM_IMAGE_AREA_S stArea;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                            /* Reserved */
    }

}
