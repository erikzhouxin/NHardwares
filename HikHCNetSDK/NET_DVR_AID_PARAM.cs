using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通事件参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AID_PARAM
    {
        public ushort wParkingDuration;       // 违停检测灵敏度  10-120s
        public ushort wPedestrianDuration;    // 行人持续时间    1-120s
        public ushort wDebrisDuration;        // 抛洒物持续时间  10-120s
        public ushort wCongestionLength;      // 拥堵长度阈值    5-200（米）
        public ushort wCongestionDuration;    // 拥堵持续参数    10-120s
        public ushort wInverseDuration;       // 逆行持续时间    1-10s
        public ushort wInverseDistance;       // 逆行距离阈值 单位m 范围[2-100] 默认 10米
        public ushort wInverseAngleTolerance; // 允许角度偏差 90-180度,车流与逆行允许的夹角
        public ushort wIllegalParkingTime;    // 违停时间[4,60]，单位：分钟 ,TFS(交通违章取证) 城市模式下
        public ushort wIllegalParkingPicNum;  // 违停图片数量[1,6], TFS(交通违章取证) 城市模式下
        public byte byMergePic;             // 图片拼接,TFS 城市模式下 0- 不拼接 1- 拼接
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;             // 保留字节
    }



}
