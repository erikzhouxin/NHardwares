using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Ip可视对讲音频相关参数配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_IP_VIEW_AUDIO_CFG
    {
        public uint dwSize;
        public byte byAudioEncPri1; //音频编码优先级1，0-OggVorbis，1-G711_U，2-G711_A， 5-MPEG2,6-G726，7-AAC
        public byte byAudioEncPri2; //音频编码优先级2，当sip服务器不支持音频编码1时会使用音频编码2，0-OggVorbis，1-G711_U，2-G711_A， 5-MPEG2,6-G726，7-AAC
        public ushort wAudioPacketLen1; //音频编码1数据包长度
        public ushort wAudioPacketLen2; //音频编码2数据包长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
