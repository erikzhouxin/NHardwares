using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GEOLACATION_INFO_S
    {
        public float fLongitude;       /* Longitude */
        public float fLatitude;        /* Latitude */
    };

}
