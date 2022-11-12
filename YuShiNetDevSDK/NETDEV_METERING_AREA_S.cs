using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_METERING_AREA_S
    {
        public NETDEV_AREA_TOP_LEFT_S stAreaTopLeft;           /* 左上角区域  结构体见#NETDEV_AREA_TOP_LEFT_S*/
        public NETDEV_AREA_BOT_RIGHT_S stAreaBotRight;          /* 右下角区域  结构体见#NETDEV_AREA_BOT_RIGHT_S*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
