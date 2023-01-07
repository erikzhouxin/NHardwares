using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道压缩参数(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSIONCFG_EX
    {
        public uint dwSize;
        public NET_DVR_COMPRESSION_INFO_EX struRecordPara;//录像
        public NET_DVR_COMPRESSION_INFO_EX struNetPara;//网传
    }
}
