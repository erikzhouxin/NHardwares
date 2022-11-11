using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 客流量统计 结构体定义 Passenger flow statistic Structure definition
     * @attention 无 None
     */
    public struct NETDEV_TRAFFIC_STATISTICS_DATA_S
    {
        public Int32 dwSize;                 /*报表长度 根据不同报表类型长度不同  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwEnterCount;        /*进入人数计数值 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwExitCount;         /*离开人数计数值 */
    }

}
