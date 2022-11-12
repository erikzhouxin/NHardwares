using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POINT_S
    {
        public Int32 dwPointX;     /* 横坐标,万分比 */
        public Int32 dwPointY;     /* 纵坐标,万分比 */
    }

}
