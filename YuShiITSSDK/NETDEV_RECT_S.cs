using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 矩形区域 结构体定义 Rectangle Area  Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECT_S
    {
        public Int32 dwLeft;                               /* x轴左点值[0,10000] X axis left point value [0,10000] */
        public Int32 dwTop;                                /* y轴顶点值[0,10000] Y axis top point value [0,10000] */
        public Int32 dwRight;                              /* x轴右点值[0,10000] X axis right point value [0,10000] */
        public Int32 dwBottom;                             /* y轴底点值[0,10000] Y axis bottom point value [0,10000] */
    }

}
