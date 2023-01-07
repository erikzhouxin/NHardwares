namespace System.Data.HikHCNetSDK
{
    public enum TRAFFIC_DATA_VARY_TYPE_EX_ENUM
    {
        ENUM_TRAFFIC_VARY_NO = 0x00,   //无变化
        ENUM_TRAFFIC_VARY_VEHICLE_ENTER = 0x01,   //车辆进入虚拟线圈
        ENUM_TRAFFIC_VARY_VEHICLE_LEAVE = 0x02,   //车辆离开虚拟线圈
        ENUM_TRAFFIC_VARY_QUEUE = 0x04,   //队列变化
        ENUM_TRAFFIC_VARY_STATISTIC = 0x08,   //统计数据变化（每分钟变化一次包括平均速度，车道空间/时间占有率，交通状态）        
    }



}
