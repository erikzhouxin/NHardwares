namespace System.Data.HikHCNetSDK
{
    public enum ITS_ABILITY_TYPE
    {
        ITS_CONGESTION_ABILITY = 0x01,      //拥堵
        ITS_PARKING_ABILITY = 0x02,      //停车  
        ITS_INVERSE_ABILITY = 0x04,      //逆行
        ITS_PEDESTRIAN_ABILITY = 0x08,      //行人                      
        ITS_DEBRIS_ABILITY = 0x10,      //遗留物 抛洒物碎片
        ITS_SMOKE_ABILITY = 0x20,      //烟雾-隧道
        ITS_OVERLINE_ABILITY = 0x40,      //压线
        ITS_VEHICLE_CONTROL_LIST_ABILITY = 0x80,        //禁止名单数据
        ITS_SPEED_ABILITY = 0x100,      //超速	
        ITS_LANE_VOLUME_ABILITY = 0x010000,  //车道流量
        ITS_LANE_VELOCITY_ABILITY = 0x020000,  //车道平均速度
        ITS_TIME_HEADWAY_ABILITY = 0x040000,  //车头时距
        ITS_SPACE_HEADWAY_ABILITY = 0x080000,  //车头间距
        ITS_TIME_OCCUPANCY_RATIO_ABILITY = 0x100000,  //车道占有率，（时间上)
        ITS_SPACE_OCCUPANCY_RATIO_ABILITY = 0x200000,  //车道占有率，百分比计算（空间上)
        ITS_LANE_QUEUE_ABILITY = 0x400000,  //排队长度
        ITS_VEHICLE_TYPE_ABILITY = 0x800000,  //车辆类型
        ITS_TRAFFIC_STATE_ABILITY = 0x1000000  //交通状态
    }



}
