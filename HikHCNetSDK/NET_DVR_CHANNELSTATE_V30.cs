using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道状态(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANNELSTATE_V30
    {
        public byte byRecordStatic;//通道是否在录像,0-不录像,1-录像
        public byte bySignalStatic;//连接的信号状态,0-正常,1-信号丢失
        public byte byHardwareStatic;//通道硬件状态,0-正常,1-异常,例如DSP死掉
        public byte byRes1;//保留
        public uint dwBitRate;//实际码率
        public uint dwLinkNum;//客户端连接的个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LINK, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPADDR[] struClientIP;//客户端的IP地址
        public uint dwIPLinkNum;//如果该通道为IP接入，那么表示IP接入当前的连接数
        public byte byExceedMaxLink;        // 是否超出了单路6路连接数 0 - 未超出, 1-超出
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwChannelNo;    //当前的通道号，0xffffffff表示无效

        public void Init()
        {
            struClientIP = new NET_DVR_IPADDR[HikHCNetSdk.MAX_LINK];

            for (int i = 0; i < HikHCNetSdk.MAX_LINK; i++)
            {
                struClientIP[i].Init();
            }
            byRes = new byte[12];
        }
    }

}
