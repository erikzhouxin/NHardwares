using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道压缩参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSIONCFG
    {
        public uint dwSize;
        public NET_DVR_COMPRESSION_INFO struRecordPara;//录像/事件触发录像
        public NET_DVR_COMPRESSION_INFO struNetPara;//网传/保留
    }
}
