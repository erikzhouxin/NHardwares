using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //违规检测参数结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_VIOLATION_DETECT_PARAM
    {
        public uint dwVioDetectType; //违规检测类型, 按位表示, 详见ITC_VIOLATION_DETECT_TYPE ,0-不启用,1-启用
        public byte byDriveLineSnapTimes; //压车道线抓拍张数,2-3
        public byte byReverseSnapTimes; //逆行抓拍,2-3
        public ushort wStayTime; //机占非停留时间（该时间后抓拍），单位s
        public byte byNonDriveSnapTimes;//机占非抓拍张数2-3
        public byte byChangeLaneTimes;//违法变道抓拍张数 2-3
        public byte bybanTimes;//违法禁令抓拍张数2-3
        public byte byDriveLineSnapSen;// 压线灵敏度(0~100)(3.7Ver)
        public ushort wSnapPosFixPixel; //第2,3张抓拍位置最小偏移(违反信号灯时起效)（单位：像素） 命名需改进
        public byte bySpeedTimes;//违法超速抓拍张数2-3(3.8Ver)
        public byte byTurnAroundEnable;//违章掉头使能 0~关闭 1~开启
        public byte byThirdPlateRecogTime;//第三张牌识时间 0~180s
        public byte byPostSnapTimes;//卡口抓拍张数,1-2张
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public ushort wStopLineDis;  //电警第2张违规图片与停止线的最短距离，[0,300]单位(像素)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
