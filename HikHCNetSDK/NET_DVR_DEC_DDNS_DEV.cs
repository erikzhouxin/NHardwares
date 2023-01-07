using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //动态域名取流配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DEC_DDNS_DEV
    {
        public NET_DVR_DEV_DDNS_INFO struDdnsInfo;/*流媒体服务器配置*/
        public NET_DVR_STREAM_MEDIA_SERVER struMediaServer;/* 解码通道信息 */
    }
}
