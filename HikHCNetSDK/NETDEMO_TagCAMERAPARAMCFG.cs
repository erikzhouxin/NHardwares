using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TagCAMERAPARAMCFG
    {
        public uint dwSize;
        public uint dwPowerLineFrequencyMode;/*0-50HZ; 1-60HZ*/
        public uint dwWhiteBalanceMode;/*0手动白平衡; 1自动白平衡1（范围小）; 2 自动白平衡2（范围宽，2200K-15000K）;3自动控制3*/
        public uint dwWhiteBalanceModeRGain;/*手动白平衡时有效，手动白平衡 R增益*/
        public uint dwWhiteBalanceModeBGain;/*手动白平衡时有效，手动白平衡 B增益*/
        public uint dwExposureMode;/*0 手动曝光 1自动曝光*/
        public uint dwExposureSet;/* 0-USERSET, 1-自动x2，2-自动4，3-自动81/25, 4-1/50, 5-1/100, 6-1/250, 7-1/500, 8-1/750, 9-1/1000, 10-1/2000, 11-1/4000,12-1/10,000; 13-1/100,000*/
        public uint dwExposureUserSet;/* 自动自定义曝光时间*/
        public uint dwExposureTarget;/*手动曝光时间 范围（Manumal有效，微秒）*/
        public uint dwIrisMode;/*0 自动光圈 1手动光圈*/
        public uint dwGainLevel;/*增益：0-100*/
        public uint dwBrightnessLevel;/*0-100*/
        public uint dwContrastLevel;/*0-100*/
        public uint dwSharpnessLevel;/*0-100*/
        public uint dwSaturationLevel;/*0-100*/
        public uint dwHueLevel;/*0-100，（保留）*/
        public uint dwGammaCorrectionEnabled;/*0 dsibale  1 enable*/
        public uint dwGammaCorrectionLevel;/*0-100*/
        public uint dwWDREnabled;/*宽动态：0 dsibale  1 enable*/
        public uint dwWDRLevel1;/*0-F*/
        public uint dwWDRLevel2;/*0-F*/
        public uint dwWDRContrastLevel;/*0-100*/
        public uint dwDayNightFilterType;/*日夜切换：0 day,1 night,2 auto */
        public uint dwSwitchScheduleEnabled;/*0 dsibale  1 enable,(保留)*/
        //模式1(保留)
        public uint dwBeginTime;    /*0-100*/
        public uint dwEndTime;/*0-100*/
        //模式2
        public uint dwDayToNightFilterLevel;//0-7
        public uint dwNightToDayFilterLevel;//0-7
        public uint dwDayNightFilterTime;//(60秒)
        public uint dwBacklightMode;/*背光补偿:0 USERSET 1 UP、2 DOWN、3 LEFT、4 RIGHT、5MIDDLE*/
        public uint dwPositionX1;//（X坐标1）
        public uint dwPositionY1;//（Y坐标1）
        public uint dwPositionX2;//（X坐标2）
        public uint dwPositionY2;//（Y坐标2）
        public uint dwBacklightLevel;/*0x0-0xF*/
        public uint dwDigitalNoiseRemoveEnable; /*数字去噪：0 dsibale  1 enable*/
        public uint dwDigitalNoiseRemoveLevel;/*0x0-0xF*/
        public uint dwMirror; /* 镜像：0 Left;1 Right,;2 Up;3Down */
        public uint dwDigitalZoom;/*数字缩放:0 dsibale  1 enable*/
        public uint dwDeadPixelDetect;/*坏点检测,0 dsibale  1 enable*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;
    }
}
