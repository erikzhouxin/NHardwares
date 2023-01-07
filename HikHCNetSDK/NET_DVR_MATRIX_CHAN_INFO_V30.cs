using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_CHAN_INFO_V30
    {
        public uint dwEnable;/* 是否启用 0－否 1－启用*/
        public NET_DVR_STREAM_MEDIA_SERVER_CFG streamMediaServerCfg;
        public NET_DVR_DEV_CHAN_INFO struDevChanInfo;/* 轮循解码通道信息 */
    }
}
