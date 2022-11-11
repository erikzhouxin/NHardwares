using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief OSD字符叠加信息 OSD text overlay information
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TEXT_OVERLAY_S
    {
        public Int32 bEnableFlag;                /** OSD字符叠加使能, BOOL_TRUE为使能,BOOL_FALSE为非使能 , BOOL_TRUE,BOOL_FALSE * Enable OSD text overlay, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public NETDEV_AREA_SCOPE_S stAreaScope;                /** OSD字符叠加区域坐标 * OSD text overlay area coordinates */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_OSD_TEXT_MAX_LEN)]
        public byte[] OSDText;    /** OSD字符叠加名称字符串 * OSD text overlay name strings */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] byRes;                            /*保留字段 Reserved */
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
