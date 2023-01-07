namespace System.Data.HikHCNetSDK
{
    //交通事件类型
    public enum TRAFFIC_AID_TYPE
    {
        CONGESTION = 0x01,    //拥堵
        PARKING = 0x02,    //停车  
        INVERSE = 0x04,    //逆行
        PEDESTRIAN = 0x08,    //行人                      
        DEBRIS = 0x10,    //遗留物 抛洒物碎片 
        SMOKE = 0x20,    //烟雾  
        OVERLINE = 0x40,     //压线
        VEHICLE_CONTROL_LIST = 0x80,  //禁止名单数据
        SPEED = 0x100  //超速
    }



}
