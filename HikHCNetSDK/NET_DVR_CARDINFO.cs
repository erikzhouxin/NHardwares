using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //硬解码预览参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CARDINFO
    {
        public int lChannel;//通道号
        public int lLinkMode;//最高位(31)为0表示主码流，为1表示子，0－30位表示码流连接方式:0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式，4-电话线，5－128k宽带，6－256k宽带，7－384k宽带，8－512k宽带；
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string sMultiCastIP;
        public NET_DVR_DISPLAY_PARA struDisplayPara;
    }

}
