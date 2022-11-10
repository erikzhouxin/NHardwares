using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagMwIVAParkingSpaces
     * @brief              车位区域信息(NEW)
     * @attention  无
     */
    public struct NETDEV_ITS_PARKING_SPACES_S
    {
        public Int32 ulParkingDetstaus;                                              /**< 检测使能标志, 0表示不使能,1表示使能,2表示无效 */
        public Int32 ulParkingLotID;                                                 /**< 车位号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string[] szAreaDesc;                                                  /**< 车位所属区号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string[] szCustomSpaceDescID;                                         /**< 自定义车位号 */
        public NETDEV_POLYGON_S stParkingSpace;                                      /**< 车位区域坐标,多边形，最多支持12个点 */
    };

}
