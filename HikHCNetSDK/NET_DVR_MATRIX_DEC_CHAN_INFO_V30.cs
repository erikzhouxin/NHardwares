using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DEC_CHAN_INFO_V30
    {
        public uint dwSize;
        public NET_DVR_STREAM_MEDIA_SERVER_CFG streamMediaServerCfg;/*流媒体服务器配置*/
        public NET_DVR_DEV_CHAN_INFO struDevChanInfo;/* 解码通道信息 */
        public uint dwDecState;/* 0-动态解码 1－循环解码 2－按时间回放 3－按文件回放 */
        public NET_DVR_TIME StartTime;/* 按时间回放开始时间 */
        public NET_DVR_TIME StopTime;/* 按时间回放停止时间 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string sFileName;/* 按文件回放文件名 */
        public uint dwGetStreamMode;/*取流模式:1-主动，2-被动*/
        public NET_DVR_MATRIX_PASSIVEMODE struPassiveMode;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
