using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DEC_CHAN_INFO_V41
    {
        public uint dwSize;
        public byte byStreamMode;/*取流模式：0- 无效，1- 通过IP或域名取流，2- 通过URL取流，3- 通过动态域名解析向设备取流*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_DEC_STREAM_MODE uDecStreamMode;/*取流信息*/
        public uint dwPlayMode;/*解码状态：0-动态解码，1－循环解码，2－按时间回放，3－按文件回放*/
        public NET_DVR_TIME StartTime;/* 按时间回放开始时间 */
        public NET_DVR_TIME StopTime;/* 按时间回放停止时间 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string sFileName;/* 按文件回放文件名 */
        public uint dwGetStreamMode;/*取流模式:1-主动，2-被动*/
        public NET_DVR_MATRIX_PASSIVEMODE struPassiveMode;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
