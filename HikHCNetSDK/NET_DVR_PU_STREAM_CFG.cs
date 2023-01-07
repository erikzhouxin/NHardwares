using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PU_STREAM_CFG
    {
        public uint dwSize;
        public NET_DVR_STREAM_MEDIA_SERVER_CFG struStreamMediaSvrCfg;
        public NET_DVR_DEV_CHAN_INFO struDevChanInfo;
    }

}
