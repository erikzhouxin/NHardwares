using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REV_TIMEOUT_S
    {
        public Int32 dwRevTimeOut;                /* Set receive time out */
        public Int32 dwFileReportTimeOut;         /* Set file report time out*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                              /* Reserved */
    };

}
