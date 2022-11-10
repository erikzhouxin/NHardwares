using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_TOP_LEFT_S
    {
        public Int32 dwTopLeftX;     /* 左上角横坐标(比例)：区域测光模式范围: [0, 100]。Upper left corner X [0, 100]  */
        public Int32 dwTopLeftY;     /* 左上角纵坐标(比例)：区域测光模式范围: [0, 100]。Upper left corner Y [0, 100]  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
