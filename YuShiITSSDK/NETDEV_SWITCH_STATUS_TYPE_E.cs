namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_SWITCH_STATUS_TYPE_E
    * @brief 输出开关量类型枚举 
    * @attention 卡口电警对应IO口F1-F4
    */
    public enum NETDEV_SWITCH_STATUS_TYPE_E
    {
        NETDEV_SWITCH_STATUS_F1 = 0,               /*F1IO口*/
        NETDEV_SWITCH_STATUS_F2 = 1,               /*F2IO口*/
        NETDEV_SWITCH_STATUS_F3 = 2,               /*F3IO口*/
        NETDEV_SWITCH_STATUS_F4 = 3,               /*F4IO口*/
        NETDEV_SWITCH_STATUS_INVALID = 0xFFFF           /* 无效值  Invalid value */
    }

}
