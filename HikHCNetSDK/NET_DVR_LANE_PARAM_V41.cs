using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LANE_PARAM_V41
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName; // 车道规则名称
        public byte byRuleID;             // 规则序号，为规则配置结构下标，0-7 
        public byte byLaneType;          // 车道上行或下行
        public byte byTrafficState;       // 车道的交通状态，0-无效，1-畅通，2-拥挤，3-堵塞
        public byte byRes1;               // 保留
        public uint dwVaryType;           // 车道交通参数变化类型参照  TRAFFIC_DATA_VARY_TYPE_EX_ENUM，按位区分
        public uint dwTpsType;            // 数据变化类型标志，表示当前上传的统计参数中，哪些数据有效，参照ITS_TPS_TYPE,按位区分
        public uint dwLaneVolume;        // 车道流量，统计有多少车子通过
        public uint dwLaneVelocity;       // 车道速度，公里计算
        public uint dwTimeHeadway;       // 车头时距，以秒计算
        public uint dwSpaceHeadway;       // 车头间距，以米来计算
        public float fSpaceOccupyRation;   // 车道占有率，百分比计算（空间上)
        public float fTimeOccupyRation;    // 时间占有率，百分比计算
        public uint dwLightVehicle;       // 小型车数量
        public uint dwMidVehicle;         // 中型车数量
        public uint dwHeavyVehicle;       // 重型车数量
        public NET_DVR_LANE_QUEUE struLaneQueue;        // 车道队列长度
        public NET_VCA_POINT struRuleLocation;     // 规则位置虚拟线圈的中心
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           // 保留
    }



}
