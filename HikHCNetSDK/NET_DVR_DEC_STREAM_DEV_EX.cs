using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DEC_STREAM_DEV_EX
    {
        public NET_DVR_STREAM_MEDIA_SERVER struStreamMediaSvrCfg;/*流媒体服务器配置*/
        public NET_DVR_DEV_CHAN_INFO_EX struDevChanInfo;/* 解码通道信息 */
    }
}
