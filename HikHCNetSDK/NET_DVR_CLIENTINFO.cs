using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CLIENTINFO
    {
        public Int32 lChannel;//通道号
        public Int32 lLinkMode;//最高位(31)为0表示主码流，为1表示子码流，0－30位表示码流连接方式: 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式，4-音视频分开(TCP)
        public IntPtr hPlayWnd;//播放窗口的句柄,为NULL表示不播放图象
        public string sMultiCastIP;//多播组地址
    }

}
