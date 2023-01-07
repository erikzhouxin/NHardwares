using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DEC_CHAN_INFO
    {
        public uint dwSize;
        public NET_DVR_MATRIX_DECINFO struDecChanInfo;/* 解码通道信息 */
        public uint dwDecState;/* 0-动态解码 1－循环解码 2－按时间回放 3－按文件回放 */
        public NET_DVR_TIME StartTime;/* 按时间回放开始时间 */
        public NET_DVR_TIME StopTime;/* 按时间回放停止时间 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string sFileName;/* 按文件回放文件名 */
    }
}
