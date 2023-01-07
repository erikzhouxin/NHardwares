using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PU_STREAM_CFG_SCENE
    {
        public NET_DVR_STREAM_MEDIA_SERVER_CFG_SCENE streamMediaServerCfg;
        public NET_DVR_DEV_CHAN_INFO_SCENE struDevChanInfo;
    }
}
