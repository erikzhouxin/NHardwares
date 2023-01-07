using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //SDK状态信息(9000新增)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SDKSTATE
    {
        public uint dwTotalLoginNum;//当前login用户数
        public uint dwTotalRealPlayNum;//当前realplay路数
        public uint dwTotalPlayBackNum;//当前回放或下载路数
        public uint dwTotalAlarmChanNum;//当前建立报警通道路数
        public uint dwTotalFormatNum;//当前硬盘格式化路数
        public uint dwTotalFileSearchNum;//当前日志或文件搜索路数
        public uint dwTotalLogSearchNum;//当前日志或文件搜索路数
        public uint dwTotalSerialNum;//当前透明通道路数
        public uint dwTotalUpgradeNum;//当前升级路数
        public uint dwTotalVoiceComNum;//当前语音转发路数
        public uint dwTotalBroadCastNum;//当前语音广播路数
        public uint dwTotalListenNum;       //当前网络监听路数
        public uint dwEmailTestNum;       //当前邮件计数路数
        public uint dwBackupNum;          // 当前文件备份路数
        public uint dwTotalInquestUploadNum; //当前审讯上传路数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;
    }

}
