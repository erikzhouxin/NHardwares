using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_OSD_CFG_S
    {
        public NETDEV_OSD_TIME_S stTimeOSD;        /* OSD  Information of channel time OSD */
        public NETDEV_OSD_TEXT_OVERLAY_S stNameOSD;        /* OSD  Information of channel name OSD */
        public Int16 wTextNum;         /* OSD  Text OSD number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM)]
        public NETDEV_OSD_TEXT_OVERLAY_S[] astTextOverlay;   /* OSD  Information of channel OSD text overlay */
    }

}
