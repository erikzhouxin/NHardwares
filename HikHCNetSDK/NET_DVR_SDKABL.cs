using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //SDK功能支持信息(9000新增)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SDKABL
    {
        public uint dwMaxLoginNum;//最大login用户数 MAX_LOGIN_USERS
        public uint dwMaxRealPlayNum;//最大realplay路数 WATCH_NUM
        public uint dwMaxPlayBackNum;//最大回放或下载路数 WATCH_NUM
        public uint dwMaxAlarmChanNum;//最大建立报警通道路数 ALARM_NUM
        public uint dwMaxFormatNum;//最大硬盘格式化路数 SERVER_NUM
        public uint dwMaxFileSearchNum;//最大文件搜索路数 SERVER_NUM
        public uint dwMaxLogSearchNum;//最大日志搜索路数 SERVER_NUM
        public uint dwMaxSerialNum;//最大透明通道路数 SERVER_NUM
        public uint dwMaxUpgradeNum;//最大升级路数 SERVER_NUM
        public uint dwMaxVoiceComNum;//最大语音转发路数 SERVER_NUM
        public uint dwMaxBroadCastNum;//最大语音广播路数 MAX_CASTNUM
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;
    }

}
