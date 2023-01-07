using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALRAM_FIXED_HEADER
    {
        public uint dwAlarmType;              /*0-信号量报警,1-硬盘满,2-信号丢失，3－移动侦测，4－硬盘未格式化,5-写硬盘出错,6-遮挡报警，7-制式不匹配, 8-非法访问，9-视频信号异常，10-录像异常，11-智能场景变化，12-阵列异常，13-前端/录像分辨率不匹配*/
        public NET_DVR_TIME_EX struAlarmTime;   //发生报警的时间
        public UNION_ALARMINFO_FIXED uStruAlarm;
    }

}
