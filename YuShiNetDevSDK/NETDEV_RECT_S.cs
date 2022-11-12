using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECT_S
    {
        public Int32 dwLeft;                               /* X axis left point value [0,10000] */
        public Int32 dwTop;                                /* Y axis top point value [0,10000] */
        public Int32 dwRight;                              /* X axis right point value [0,10000] */
        public Int32 dwBottom;                             /* Y axis bottom point value [0,10000] */
    }

}
