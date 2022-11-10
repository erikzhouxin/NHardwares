using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_SCOPE_S
    {
        public Int32 dwLocateX;             /** x[0,10000] * Coordinates of top point x [0,10000] */
        public Int32 dwLocateY;             /** y[0,10000] * Coordinates of top point y [0,10000] */
    };

}
