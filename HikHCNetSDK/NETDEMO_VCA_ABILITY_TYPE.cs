namespace System.Data.HikHCNetSDK
{
    //行为分析能力类型
    public enum VCA_ABILITY_TYPE : uint
    {
        TRAVERSE_PLANE_ABILITY = 0x01,       //穿越警戒面
        ENTER_AREA_ABILITY = 0x02,       //进入区域
        EXIT_AREA_ABILITY = 0x04,       //离开区域
        INTRUSION_ABILITY = 0x08,       //入侵
        LOITER_ABILITY = 0x10,       //徘徊
        LEFT_TAKE_ABILITY = 0x20,       //物品遗留拿取
        PARKING_ABILITY = 0x40,       //停车
        RUN_ABILITY = 0x80,       //快速移动
        HIGH_DENSITY_ABILITY = 0x100,      //人员聚集
        LF_TRACK_ABILITY = 0x200,      //球机跟踪
        VIOLENT_MOTION_ABILITY = 0x400,      //剧烈运动检测
        REACH_HIGHT_ABILITY = 0x800,      //攀高检测
        GET_UP_ABILITY = 0x1000,     //起身检测
        LEFT_ABILITY = 0x2000,     //物品遗留
        TAKE_ABILITY = 0x4000,     //物品拿取
        LEAVE_POSITION = 0x8000,     //离岗
        TRAIL_ABILITY = 0x10000,    //尾随 
        KEY_PERSON_GET_UP_ABILITY = 0x20000,    //重点人员起身检测
        FALL_DOWN_ABILITY = 0x80000,    //倒地
        AUDIO_ABNORMAL_ABILITY = 0x100000,   //声强突变
        ADV_REACH_HEIGHT_ABILITY = 0x200000,   //折线攀高
        TOILET_TARRY_ABILITY = 0x400000,   //如厕超时
        YARD_TARRY_ABILITY = 0x800000,   //放风场滞留
        ADV_TRAVERSE_PLANE_ABILITY = 0x1000000,  //折线警戒面
        HUMAN_ENTER_ABILITY = 0x10000000, //人靠近ATM ,只在ATM_PANEL模式下支持
        OVER_TIME_ABILITY = 0x20000000, //操作超时,只在ATM_PANEL模式下支持
        STICK_UP_ABILITY = 0x40000000, //贴纸条
        INSTALL_SCANNER_ABILITY = 0x80000000  //安装读卡器
    }

}
