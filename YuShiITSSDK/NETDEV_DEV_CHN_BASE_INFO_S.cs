using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_BASE_INFO_S
    {
        public Int32 dwChannelID;
        public Int32 dwDevID;
        public Int32 dwOrgID;
        public Int32 dwChnType;                                        /* See NETDEV_CHN_TYPE_E */
        public Int32 dwChnStatus;                                      /* See NETDEV_CHN_STATUS_E */
        public Int32 dwChnIndex;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szChnName;
        public UInt32 udwRight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
