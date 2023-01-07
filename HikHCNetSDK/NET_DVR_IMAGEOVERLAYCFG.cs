using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图像叠加信息配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IMAGEOVERLAYCFG
    {
        public uint dwSize;
        public byte byOverlayInfo;//叠加使能开关，0-不叠加，1-叠加
        public byte byOverlayMonitorInfo;//是否叠加监测点信息，0-不叠加，1-叠加
        public byte byOverlayTime;//是否叠加时间，0-不叠加，1-叠加
        public byte byOverlaySpeed;//是否叠加速度，0-不叠加，1-叠加
        public byte byOverlaySpeeding;//是否叠加超速比例，0-不叠加，1-叠加
        public byte byOverlayLimitFlag;//是否叠加限速标志，0-不叠加，1-叠加
        public byte byOverlayPlate;//是否叠加车牌号，0-不叠加，1-叠加
        public byte byOverlayColor;//是否叠加车身颜色，0-不叠加，1-叠加
        public byte byOverlayLength;//是否叠加车长，0-不叠加，1-叠加
        public byte byOverlayType;//是否叠加车型，0-不叠加，1-叠加
        public byte byOverlayColorDepth;//是否叠加车身颜色深浅，0-不叠加，1-叠加
        public byte byOverlayDriveChan;//是否叠加车道，0-不叠加，1-叠加
        public byte byOverlayMilliSec; //叠加毫秒信息 0-不叠加，1-叠加
        public byte byOverlayIllegalInfo; //叠加违章信息 0-不叠加，1-叠加
        public byte byOverlayRedOnTime;  //叠加红灯已亮时间 0-不叠加，1-叠加
        public byte byFarAddPlateJpeg;      //远景图是否叠加车牌截图,0-不叠加,1-叠加
        public byte byNearAddPlateJpeg;      //近景图是否叠加车牌截图,0-不叠加,1-叠加
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byMonitorInfo1;    //监测点信息1
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byMonitorInfo2; //检测点信息2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 52, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }



}
