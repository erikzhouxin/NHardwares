using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSIONCFG_NEW
    {
        public uint dwSize;
        public NET_DVR_COMPRESSION_INFO_EX struLowCompression;//定时录像
        public NET_DVR_COMPRESSION_INFO_EX struEventCompression;//事件触发录像
    }

}
