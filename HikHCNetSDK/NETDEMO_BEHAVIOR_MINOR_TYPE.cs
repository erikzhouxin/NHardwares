namespace System.Data.HikHCNetSDK
{
    //行为分析主类型对应的此类型， 0xffff表示全部
    public enum BEHAVIOR_MINOR_TYPE
    {
        EVENT_TRAVERSE_PLANE = 0,// 穿越警戒面,
        EVENT_ENTER_AREA,//目标进入区域,支持区域规则
        EVENT_EXIT_AREA,//目标离开区域,支持区域规则
        EVENT_INTRUSION,// 周界入侵,支持区域规则
        EVENT_LOITER,//徘徊,支持区域规则
        EVENT_LEFT_TAKE,//丢包捡包,支持区域规则
        EVENT_PARKING,//停车,支持区域规则
        EVENT_RUN,//奔跑,支持区域规则
        EVENT_HIGH_DENSITY,//区域内人员密度,支持区域规则
        EVENT_STICK_UP,//贴纸条,支持区域规则
        EVENT_INSTALL_SCANNER,//安装读卡器,支持区域规则
        EVENT_OPERATE_OVER_TIME,        // 操作超时
        EVENT_FACE_DETECT,              // 异常人脸
        EVENT_LEFT,                     // 物品遗留
        EVENT_TAKE,                      // 物品拿取
        EVENT_LEAVE_POSITION,         //离岗事件
        EVENT_TRAIL_INFO = 16,            //尾随
        EVENT_FALL_DOWN_INFO = 19,                 //倒地
        EVENT_OBJECT_PASTE = 20,        // 异物粘贴区域
        EVENT_FACE_CAPTURE_INFO = 21,                //正常人脸
        EVENT_MULTI_FACES_INFO = 22,                  //多张人脸
        EVENT_AUDIO_ABNORMAL_INFO = 23,             //声强突变
        EVENT_DETECT = 24                  //智能侦测
    }

}
