using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //闪光灯配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FLASH_OUTCFG
    {
        public uint dwSize;
        public byte byMode;//闪光灯闪烁模式，0-不闪，1-闪，2-关联闪，3-轮闪
        public byte byRelatedIoIn;//闪光灯关联的输入IO号（关联闪时此参数有效）
        public byte byRecognizedLane;  /*关联的IO号，按位表示，bit0表示IO1是否关联，0-不关联，1-关联*/
        public byte byDetectBrightness;/*自动检测亮度使能闪光灯0-不检测；1-检测*/
        public byte byBrightnessThreld;/*使能闪光灯亮度阈值，范围[0,100],高于阈值闪*/
        public byte byStartHour;        //开始时间-小时,取值范围0-23
        public byte byStartMinute;      //开始时间-分,取值范围0-59
        public byte byEndHour;          //结束时间-小时,取值范围0-23
        public byte byEndMinute;        //结束时间-分,取值范围0-59
        public byte byFlashLightEnable; //设置闪光灯时间使能:0-关;1-开
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
