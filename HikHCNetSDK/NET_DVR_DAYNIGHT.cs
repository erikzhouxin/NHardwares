using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //日夜转换功能配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DAYNIGHT
    {
        public byte byDayNightFilterType; /*日夜切换：0-白天，1-夜晚，2-自动，3-定时，4-报警输入触发*/
        public byte bySwitchScheduleEnabled; /*0 dsibale  1 enable,(保留)*/
        //定时模式参数
        public byte byBeginTime; /*开始时间（小时），0-23*/
        public byte byEndTime; /*结束时间（小时），0-23*/
        //模式2
        public byte byDayToNightFilterLevel; //0-7
        public byte byNightToDayFilterLevel; //0-7
        public byte byDayNightFilterTime;//(60秒)
                                         //定时模式参数
        public byte byBeginTimeMin; //开始时间（分），0-59
        public byte byBeginTimeSec; //开始时间（秒），0-59
        public byte byEndTimeMin; //结束时间（分），0-59
        public byte byEndTimeSec; //结束时间（秒），0-59
                                  //报警输入触发模式参数
        public byte byAlarmTrigState; //报警输入触发状态，0-白天，1-夜晚
    }



}
