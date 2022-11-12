using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ABSOLUTE_MOVE_S
    {
        public float fPanTiltX;                         /* 绝对水平坐标  Absolute horizontal coordinates*/
        public float fPanTiltY;                         /* 绝对竖直坐标  Absolute vertical coordinates*/
        public float fZoomX;                            /* 绝对聚焦倍数  Absolute multiples*/
    };

}
