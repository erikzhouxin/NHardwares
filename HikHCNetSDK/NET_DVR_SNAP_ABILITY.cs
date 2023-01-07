using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SNAP_ABILITY
    {
        public uint dwSize;
        public byte byIoInNum;//IO输入口数
        public byte byIoOutNum;//IO输出口数
        public byte bySingleSnapNum;//单IO触发组数
        public byte byLightModeArrayNum;//红绿灯模式组数
        public byte byMeasureModeArrayNum;//测速模式组数
        public byte byPlateEnable; //车牌识别能力
        public byte byLensMode;//镜头模式0-CCD,1-CMOS
        public byte byPreTriggerSupport; //是否支持原触发模式，0-支持，1-不支持
        public uint dwAbilityType; //支持的触发模式能力，按位表示，定义见ITC_MAINMODE_ABILITY
        public byte byIoSpeedGroup; //支持的IO测速组数
        public byte byIoLightGroup; //支持的IO红绿灯组数
        public byte byRecogRegionType; //牌识区域支持的类型，详见定义ITC_RECOG_REGION_TYPE
        public byte bySupport; //设备能力，按位表示，0-不支持，1-支持
                               // bySupport&0x1，表示是否支持扩展的字符叠加配置
                               // bySupport&0x2，表示是否支持扩展的校时配置结构
                               // bySupport&0x4, 表示是否支持多网卡(多网隔离)
                               // bySupport&0x8, 表示是否支持网卡的bonding功能(网络容错)
                               // bySupport&0x10, 表示是否支持语音对讲
                               //2013-07-09 能力集返回
        public ushort wSupportMultiRadar;// 设备能力，按位表示，0-不支持，1-支持
                                         // wSupportMultiRadar&0x1，表示 卡口RS485雷达 支持车道关联雷达处理
                                         // wSupportMultiRadar&0x2，表示 卡口虚拟线圈 支持车道关联雷达处理
                                         // wSupportMultiRadar&0x4，表示 混行卡口 支持车道关联雷达处理
                                         // wSupportMultiRadar&0x8，表示 视频检测 支持车道关联雷达处理
        public byte byICRPresetNum;
        // 表示支持的ICR预置点（滤光片偏移点）数
        public byte byICRTimeSlot;//表示支持的ICR的时间段数（1～8）
        public byte bySupportRS485Num;//表示支持的RS485口的数量
        public byte byExpandRs485SupportSensor;// 设备能力，按位表示，0-不支持，1-支持
                                               // byExpandRs485SupportSensor &0x1，表示电警车检器支持车检器
                                               // byExpandRs485SupportSensor &0x2，表示卡式电警车检器支持车检器
        public byte byExpandRs485SupportSignalLampDet;// 设备能力，按位表示，0-不支持，1-支持
                                                      // byExpandRs485SupportSignalLampDet &0x1，表示电警车检器支持外接信号灯检测器
                                                      // byExpandRs485SupportSignalLampDet &0x2，表示卡式电警车检器支持外接信号灯检测器
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
