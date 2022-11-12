using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TEXT_OVERLAY_S
    {
        public Int32 bEnableFlag;                /** OSD, BOOL_TRUE,BOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public NETDEV_AREA_SCOPE_S stAreaScope;                /** OSD * OSD text overlay area coordinates */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN)]
        public byte[] OSDText;    /** OSD * OSD text overlay name strings */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] byRes;                            /* Reserved */
    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct NETDEV_OSD_TEXT_OVERLAY_S
    //{
    //        public bool                    bEnableFlag;                /** OSD BOOL_TRUEBOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
    //        public NETDEV_AREA_SCOPE_S     stAreaScope;                /** OSD * OSD text overlay area coordinates */
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TEXT_MAX_LEN)]
    //        public char[]                    szOSDText;    /** OSD * OSD text overlay name strings */
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    //        public byte[]                    byRes;                               /* Reserved */
    //};
}
