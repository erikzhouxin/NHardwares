using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IP可视对讲分机配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_IP_VIEW_DEVCFG
    {
        public uint dwSize;
        public byte byDefaultRing; //默认铃音，范围1-6
        public byte byRingVolume;  //铃音音量，范围0-9
        public byte byInputVolume; //输入音量值，范围0-6
        public byte byOutputVolume; //输出音量值，范围0-9	
        public ushort wRtpPort;  //Rtp端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwPreviewDelayTime; //预览延时配置，0-30秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
