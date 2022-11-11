using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPolygon
    * @brief     多边形区域坐标结构
    * @attention 
    */
    public struct NETDEV_POLYGON_S
    {
        public Int32 ulNum;                                                                                       /**< 有效点数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8 + ItsNetDevSdk.NETDEV_LEN_4)]
        public NETDEV_AREA_SCOPE_S[] astPoint;                                                                    /**< 多边形端点坐标 */
    }

}
