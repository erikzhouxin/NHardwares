using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_POINT_S
    {
        public Int32 dwPresetID;                     /* ID  Preset ID */
        public Int32 dwStayTime;                     /* Stay time */
        public Int32 dwSpeed;                        /* Speed */
        public Int32 dwReserve;                      /* Reserved */
    };

}
