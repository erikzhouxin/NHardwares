using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_BATCH_DEL_INFO_S
    {
        public Int32 dwStatus;                             /* See NETDEV_ORG_RESPONSE_STAUTE_E */
        public Int32 dwNum;
        public IntPtr pstResultInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        public byte[] byRes;                            /*Reserved field*/
    }

}
