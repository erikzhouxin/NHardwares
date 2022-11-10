using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DST_S
    {
        public Int32 dwMonth;              /* Month(1~12)*/
        public Int32 dwWeekInMonth;        /* 1 for the first week and 5 for the last week in the month */
        public Int32 dwDayInWeek;          /* 0 for Sunday and 6 for Saturday see enumeration NETDEV_DAY_IN_WEEK_E */
        public Int32 dwHour;               /* Hour */
    };

}
