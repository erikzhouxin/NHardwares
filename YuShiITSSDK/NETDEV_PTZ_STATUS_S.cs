using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_STATUS_S
    {
        public float fPanTiltX;                         /* Absolute horizontal coordinates*/
        public float fPanTiltY;                         /* Absolute vertical coordinates*/
        public float fZoomX;                            /* Absolute multiples*/
        public Int32 enPanTiltStatus;/* PTZ Status*/
        public Int32 enZoomStatus;   /* Focus Status*/
    };

}
