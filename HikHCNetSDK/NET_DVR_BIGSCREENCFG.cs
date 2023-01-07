using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BIGSCREENCFG
    {
        public uint dwSize;
        public byte byEnable;//大屏拼接使能，0-不使能，1-使能
        public byte byModeX;/*大屏拼接模式*/
        public byte byModeY;
        public byte byMainDecodeSystem;//综合平台的解码板中该值表示主屏槽位号，64-T解码器中该值表示解码通道号
        public byte byMainDecoderDispChan;//主屏所用显示通道号，1.1netra版本新增，netra解码器有两个显示通道，都能够作为主屏。64-T中该值无效
        public byte byVideoStandard;      //大屏每个子屏制式相同 1:NTSC,2:PAL
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwResolution;         //大屏每个子屏分辨率相同
                                          //大屏拼接从屏幕信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_BIGSCREENNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLESCREENCFG[] struFollowSingleScreen;
        //起始坐标必须为基准坐标的整数倍
        public ushort wBigScreenX; //大屏在电视墙中起始X坐标
        public ushort wBigScreenY; //大屏在电视墙中起始Y坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        public void Init()
        {
            byRes1 = new byte[2];
            struFollowSingleScreen = new NET_DVR_SINGLESCREENCFG[HikHCNetSdk.MAX_BIGSCREENNUM];
            byRes2 = new byte[12];
        }
    }

}
