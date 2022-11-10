using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_TIME_S
    {
        public Int32 bEnableFlag;        /** OSD BOOL_TRUEBOOL_FALSE * Enable time OSD, BOOL_TRUE means enable and BOOL_FALSE means disable */
        public Int32 bWeekEnableFlag;    /** () * Display week or not (reserved) */
        public NETDEV_AREA_SCOPE_S stAreaScope;        /**  * Area coordinates */
        public UInt32 udwTimeFormat;      /** OSDNETDEV_OSD_TIME_FORMAT_E * Time OSD format, see NETDEV_OSD_TIME_FORMAT_E */
        public UInt32 udwDateFormat;      /** OSDNETDEV_OSD_DATE_FMT_E * Date OSD format, see NETDEV_OSD_TIME_FORMAT_E */

    };

}
