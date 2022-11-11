using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 通道OSD的基本属性信息 Basic channel OSD information
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_OSD_CFG_S
    {
        public NETDEV_OSD_TIME_S stTimeOSD;                /*通道的时间OSD信息 Information of channel time OSD */
        public NETDEV_OSD_TEXT_OVERLAY_S stNameOSD;        /*通道的名称OSD信息  Information of channel name OSD */
        public Int16 wTextNum;                             /* 字符OSD个数  Text OSD number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM)]
        public NETDEV_OSD_TEXT_OVERLAY_S[] astTextOverlay;   /*通道OSD字符叠加信息  Information of channel OSD text overlay */
    }

}
