using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VTPARAM
    {
        public uint dwSize;
        public byte byEnable;  /* 是否使能虚拟线圈，0-不使用，1-使用*/
        public byte byIsDisplay; /* 是否显示虚拟线圈，0-不显示，1-显示*/
        public byte byLoopPos; //晚间触发线圈的偏向：0-向上，1-向下
        public byte bySnapGain; /*抓拍增益*/
        public uint dwSnapShutter; /*抓拍快门速度*/
        public NET_DVR_TRIGCOORDINATE struTrigCoordinate; //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_TRIGCOORDINATE[] struRes;
        public byte byTotalLaneNum;/*视频触发的车道数1*/
        public byte byPolarLenType; /*偏振镜类型，0：不加偏振镜；1：加施耐德偏振镜。*/
        public byte byDayAuxLightMode; /*白天辅助照明模式，0：无辅助照明；1：LED灯照明；2：闪光灯照明*/
        public byte byLoopToCalRoadBright; /*用以计算路面亮度的车道(虚拟线圈)*/
        public byte byRoadGrayLowTh; /*路面亮度低阈值初始化值1*/
        public byte byRoadGrayHighTh; /*路面亮度高阈值初始化值140*/
        public ushort wLoopPosBias; /*晚间触发线圈位移30*/
        public uint dwHfrShtterInitValue; /*连续图像曝光时间的初始值2000*/
        public uint dwSnapShtterInitValue; /*抓拍图像曝光时间的初始值500*/
        public uint dwHfrShtterMaxValue; /*连续图像曝光时间的最大值20000*/
        public uint dwSnapShtterMaxValue; /*抓拍图像曝光时间的最大值1500*/
        public uint dwHfrShtterNightValue; /*晚间连续图像曝光时间的设置值3000*/
        public uint dwSnapShtterNightMinValue; /*晚间抓拍图像曝光时间的最小值3000*/
        public uint dwSnapShtterNightMaxValue; /*晚间抓拍图像曝光时间的最大值5000*/
        public uint dwInitAfe; /*增益的初始值200*/
        public uint dwMaxAfe; /*增益的最大值400*/
        public ushort wResolutionX;/* 设备当前分辨率宽*/
        public ushort wResolutionY;/* 设备当前分辨率高*/
        public uint dwGainNightValue; /*晚间增益，默认值70*/
        public uint dwSceneMode; /*场景模式， 详见SCENE_MODE */
        public uint dwRecordMode; /*录像标志：0-不录像，1-录像*/
        public NET_DVR_GEOGLOCATION struGeogLocation; /*地址位置*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VL_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrigFlag; /*触发标志，0-车头触发；1-车尾触发；2-车头/车尾都触发*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VL_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byTrigSensitive;  /*触发灵敏度，1-100*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 62, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }



}
