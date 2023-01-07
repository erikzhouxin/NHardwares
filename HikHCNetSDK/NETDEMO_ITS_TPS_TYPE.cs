namespace System.Data.HikHCNetSDK
{
    // 交通统计参数
    public enum ITS_TPS_TYPE
    {
        LANE_VOLUME = 0x01,    //车道流量
        LANE_VELOCITY = 0x02,    //车道速度
        TIME_HEADWAY = 0x04,    //车头时距
        SPACE_HEADWAY = 0x08,    //车头间距
        TIME_OCCUPANCY_RATIO = 0x10,    //车道占有率 (时间上)
        SPACE_OCCUPANCY_RATIO = 0x20,    //车道占有率，百分比计算(空间上)
        QUEUE = 0x40,    //排队长度
        VEHICLE_TYPE = 0x80,    //车辆类型
        TRAFFIC_STATE = 0x100    //交通状态
    }



}
