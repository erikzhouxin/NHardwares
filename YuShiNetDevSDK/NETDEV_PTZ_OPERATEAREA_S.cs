using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_OPERATEAREA_S
    {
        public Int32 dwBeginPointX;                           /* X[0,10000]  Area start point X value [0,10000] */
        public Int32 dwBeginPointY;                           /* Y[0,10000]  Area start point Y value [0,10000] */
        public Int32 dwEndPointX;                             /* X[0,10000]  Area end point X value [0,10000] */
        public Int32 dwEndPointY;                             /* Y [0,10000]  Area end point Y value [0,10000] */
    }

}
