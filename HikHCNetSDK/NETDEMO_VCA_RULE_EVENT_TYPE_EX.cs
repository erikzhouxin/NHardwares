namespace System.Data.HikHCNetSDK
{
    //行为分析事件类型扩展
    public enum VCA_RULE_EVENT_TYPE_EX : ushort
    {
        ENUM_VCA_EVENT_TRAVERSE_PLANE = 1,   //穿越警戒面
        ENUM_VCA_EVENT_ENTER_AREA = 2,   //目标进入区域,支持区域规则
        ENUM_VCA_EVENT_EXIT_AREA = 3,   //目标离开区域,支持区域规则
        ENUM_VCA_EVENT_INTRUSION = 4,   //周界入侵,支持区域规则
        ENUM_VCA_EVENT_LOITER = 5,   //徘徊,支持区域规则
        ENUM_VCA_EVENT_LEFT_TAKE = 6,   //物品遗留拿取,支持区域规则
        ENUM_VCA_EVENT_PARKING = 7,   //停车,支持区域规则
        ENUM_VCA_EVENT_RUN = 8,   //快速移动,支持区域规则
        ENUM_VCA_EVENT_HIGH_DENSITY = 9,   //区域内人员聚集,支持区域规则
        ENUM_VCA_EVENT_VIOLENT_MOTION = 10,  //剧烈运动检测
        ENUM_VCA_EVENT_REACH_HIGHT = 11,  //攀高检测
        ENUM_VCA_EVENT_GET_UP = 12,  //起身检测
        ENUM_VCA_EVENT_LEFT = 13,  //物品遗留
        ENUM_VCA_EVENT_TAKE = 14,  //物品拿取
        ENUM_VCA_EVENT_LEAVE_POSITION = 15,  //离岗
        ENUM_VCA_EVENT_TRAIL = 16,  //尾随
        ENUM_VCA_EVENT_KEY_PERSON_GET_UP = 17,  //重点人员起身检测
        ENUM_VCA_EVENT_FALL_DOWN = 20,  //倒地检测
        ENUM_VCA_EVENT_AUDIO_ABNORMAL = 21,  //声强突变检测
        ENUM_VCA_EVENT_ADV_REACH_HEIGHT = 22,  //折线攀高
        ENUM_VCA_EVENT_TOILET_TARRY = 23,  //如厕超时
        ENUM_VCA_EVENT_YARD_TARRY = 24,  //放风场滞留
        ENUM_VCA_EVENT_ADV_TRAVERSE_PLANE = 25,  //折线警戒面
        ENUM_VCA_EVENT_HUMAN_ENTER = 29,  //人靠近ATM,只在ATM_PANEL模式下支持   
        ENUM_VCA_EVENT_OVER_TIME = 30,  //操作超时,只在ATM_PANEL模式下支持
        ENUM_VCA_EVENT_STICK_UP = 31,  //贴纸条,支持区域规则
        ENUM_VCA_EVENT_INSTALL_SCANNER = 32   //安装读卡器,支持区域规则
    }

}
