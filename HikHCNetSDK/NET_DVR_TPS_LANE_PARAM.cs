using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //统计信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_LANE_PARAM
    {
        public byte byLane;             // 对应车道号
        public byte bySpeed;             // 车道过车平均速度
        public ushort wArrivalFlow;        //到达流量
        public uint dwLightVehicle;      // 小型车数量
        public uint dwMidVehicle;        // 中型车数量
        public uint dwHeavyVehicle;      // 重型车数量
        public uint dwTimeHeadway;      // 车头时距，以秒计算
        public uint dwSpaceHeadway;     // 车头间距，以米来计算
        public float fSpaceOccupyRation; // 空间占有率，百分比计算,浮点数*1000
        public float fTimeOccupyRation;  // 时间占有率，百分比计算,浮点数*1000
        public byte byStoppingTimes; //平均停车次数
        public byte byQueueLen;       // 堵塞状态下排队长度（比如50米）
        public byte byFlag;          //上传标识，0-表示T1时间的统计结果,1-表示T2时间的统计
        public byte byVehicelNum;         //区域车辆数
        public ushort wDelay;         //平均延误
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;               // 保留
        public uint dwNonMotor;      // 非机动车数量
    }



}
