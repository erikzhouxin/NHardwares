namespace System.Data.HikHCNetSDK
{
    //事件类型
    //主类型
    public enum MAIN_EVENT_TYPE
    {
        EVENT_MOT_DET = 0,//移动侦测
        EVENT_ALARM_IN = 1,//报警输入
        EVENT_VCA_BEHAVIOR = 2,//行为分析
        EVENT_INQUEST = 3,       //审讯事件
        EVENT_VCA_DETECTION = 4, //智能侦测
        EVENT_STREAM_INFO = 100  //流ID信息
    }

}
