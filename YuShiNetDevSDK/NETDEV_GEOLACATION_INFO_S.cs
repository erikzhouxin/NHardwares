using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GEOLACATION_INFO_S
    {
        public float fLongitude;       /* 经度 Longitude */
        public float fLatitude;        /* 纬度 Latitude */
    };

}
