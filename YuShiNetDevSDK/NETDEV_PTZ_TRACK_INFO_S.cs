using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEV_PTZ_TRACK_INFO_S
    {
        public Int32 dwTrackNum;                                               /* Number of existing patrol routes */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public String TrackName;  /* Route name */
    }

}
