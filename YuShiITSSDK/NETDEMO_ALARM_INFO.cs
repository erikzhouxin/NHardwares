namespace System.Data.YuShiITSSDK
{
    public struct NETDEMO_ALARM_INFO
    {
        public Int32 alarmType;
        public string reportAlarm;

        public NETDEMO_ALARM_INFO(int alarmTypeArg, string reportAlarmArg)
        {
            alarmType = alarmTypeArg;
            reportAlarm = reportAlarmArg;
        }
    }

}
