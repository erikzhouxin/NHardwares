using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_TIME_S
    {
        public Int32 udwChlID;                   /* ID */
        public Int64 tEarliestTime;              /* Earliest Time */
        public Int64 tLatestTime;                /* Latest Time */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                          /* Reserved */
    }

}
