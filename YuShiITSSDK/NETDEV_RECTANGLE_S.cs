using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_RECTANGLE_S
     * @brief 矩形框坐标结构
     * @attention 无
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECTANGLE_S
    {
        public NETDEV_POINT_S stTopLeft;       /**< 左上角坐标 */
        public NETDEV_POINT_S stBotRight;      /**< 右下角坐标 */
    };

}
