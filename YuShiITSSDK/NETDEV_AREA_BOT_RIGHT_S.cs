using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_BOT_RIGHT_S
    {
        public Int32 dwBottomRightX;     /* 左上角横坐标(比例)：区域测光模式范围: [0, 100]  Lower right corner x [0, 100] */
        public Int32 dwBottomRightY;     /* 左上角纵坐标(比例)：区域测光模式范围: [0, 100]  Lower right corner y [0, 100] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
