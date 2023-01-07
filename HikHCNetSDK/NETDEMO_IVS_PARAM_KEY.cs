namespace System.Data.HikHCNetSDK
{
    //参数关键字
    public enum IVS_PARAM_KEY
    {
        OBJECT_DETECT_SENSITIVE = 1,//目标检测灵敏度
        BACKGROUND_UPDATE_RATE = 2,//背景更新速度
        SCENE_CHANGE_RATIO = 3,//场景变化检测最小值
        SUPPRESS_LAMP = 4,//是否抑制车头灯
        MIN_OBJECT_SIZE = 5,//能检测出的最小目标大小
        OBJECT_GENERATE_RATE = 6,//目标生成速度
        MISSING_OBJECT_HOLD = 7,//目标消失后继续跟踪时间
        MAX_MISSING_DISTANCE = 8,//目标消失后继续跟踪距离
        OBJECT_MERGE_SPEED = 9,//多个目标交错时，目标的融合速度
        REPEATED_MOTION_SUPPRESS = 10,//重复运动抑制
        ILLUMINATION_CHANGE = 11,//光影变化抑制开关
        TRACK_OUTPUT_MODE = 12,//轨迹输出模式：0-输出目标的中心，1-输出目标的底部中心
        ENTER_CHANGE_HOLD = 13,//检测区域变化阈值
        RESUME_DEFAULT_PARAM = 255,//恢复默认关键字参数
    }
}
