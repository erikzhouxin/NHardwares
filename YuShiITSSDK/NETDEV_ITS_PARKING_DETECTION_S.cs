using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagMwIVAParkingDetection
     * @brief   车位信息(NEW)
     * @attention 
     */
    public struct NETDEV_ITS_PARKING_DETECTION_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szArea;                                                       /**< 车位所属区号 */
        public Int32 ulCarParkNums;                                                 /**< 车位区域个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_6)]
        public NETDEV_ITS_PARKING_SPACES_S[] astParkingSpacesInfo;                  /**< 车位区域信息 */
    }

}
