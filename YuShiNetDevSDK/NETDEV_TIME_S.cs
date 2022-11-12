using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_S
    {
        public Int32 dwYear;                       /* Year */
        public Int32 dwMonth;                      /* Month */
        public Int32 dwDay;                        /* Day */
        public Int32 dwHour;                       /* Hour */
        public Int32 dwMinute;                     /* Minute */
        public Int32 dwSecond;                     /* Second */
    };

}
