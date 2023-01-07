using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道压缩参数(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSIONCFG_V30
    {
        public uint dwSize;
        public NET_DVR_COMPRESSION_INFO_V30 struNormHighRecordPara;//录像 对应8000的普通
        public NET_DVR_COMPRESSION_INFO_V30 struRes;//保留 char reserveData[28];
        public NET_DVR_COMPRESSION_INFO_V30 struEventRecordPara;//事件触发压缩参数
        public NET_DVR_COMPRESSION_INFO_V30 struNetPara;//网传(子码流)
    }
}
