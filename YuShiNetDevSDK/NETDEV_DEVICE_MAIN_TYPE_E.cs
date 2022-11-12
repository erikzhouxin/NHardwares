namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_DEVICE_MAIN_TYPE_E
    {
        NETDEV_DTYPE_MAIN_ENCODE = 0,                /* 编码设备 */
        NETDEV_DTYPE_MAIN_DECODE = 1,                /* 解码设备 */
        NETDEV_DTYPE_MAIN_VMS = 2,                /* 一体机设备 */
        NETDEV_DTYPE_MAIN_DA = 3,                /* 代理设备 */
        NETDEV_DTYPE_MAIN_CLOUD = 4,                /* 云端编码设备  */
        NETDEV_DTYPE_MAIN_BAYONET = 5,                /* 卡口设备 */
        NETDEV_DTYPE_MAIN_ACS = 6,                /* 门禁主机设备 */
        NETDEV_DTYPE_MAIN_ALARMHOST = 7,                /* 报警主机设备 */

        NETDEV_DTYPE_MAIN_UNKNOWN = 0XFF              /* 未知设备 */
    }

}
