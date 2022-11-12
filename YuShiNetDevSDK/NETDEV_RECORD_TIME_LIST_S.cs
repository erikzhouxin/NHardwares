using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_TIME_LIST_S
    {
        public Int32 udwNum;                /* Channel Num */
        public IntPtr pstRecordTimes;       /* Record time list, #NETDEV_RECORD_TIME_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                          /* Reserved */
    }

}
