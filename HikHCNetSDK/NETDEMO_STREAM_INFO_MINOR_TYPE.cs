namespace System.Data.HikHCNetSDK
{
    // 主类型100，对应的小类型
    public enum STREAM_INFO_MINOR_TYPE
    {
        EVENT_STREAM_ID = 0,                // 流ID
        EVENT_TIMING = 1,                   // 定时录像
        EVENT_MOTION_DETECT = 2,            // 移动侦测
        EVENT_ALARM = 3,                    // 报警录像
        EVENT_ALARM_OR_MOTION_DETECT = 4,   // 报警或移动侦测
        EVENT_ALARM_AND_MOTION_DETECT = 5,  // 报警和移动侦测
        EVENT_COMMAND_TRIGGER = 6,          // 命令触发
        EVENT_MANNUAL = 7,                  // 手动录像
        EVENT_BACKUP_VOLUME = 8             // 存档卷录像
    }

}
