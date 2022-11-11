using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_CHL_DETAIL_INFO_S
    {
        public Int32 dwChannelID;
        public Int32 bPtzSupported;          /* Whether ptz is supported */
        public Int32 enStatus;        /* Channel status */
        public Int32 dwStreamNum;     /* Number of streams */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szChnName;                       /* Device serial number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] szReserve;
    }

}
