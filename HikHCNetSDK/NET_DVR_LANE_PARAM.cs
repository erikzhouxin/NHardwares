using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LANE_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;  //车道规则名称 
        public byte byRuleID;              //规则序号，为规则配置结构下标，0-7 
        public byte byVaryType;            //车道交通参数变化类型 参照 TRAFFIC_DATA_VARY_TYPE
        public byte byLaneType;            //车道上行或下行
        public byte byRes1;
        public uint dwLaneVolume;         //车道流量 ，统计有多少车子通过
        public uint dwLaneVelocity;        //车道速度，公里计算
        public uint dwTimeHeadway;         //车头时距，以秒计算
        public uint dwSpaceHeadway;        //车头间距，以米来计算
        public float fSpaceOccupyRation;    //车道占有率，百分比计算（空间上)
        public NET_DVR_LANE_QUEUE struLaneQueue;    //车道队列长度
        public NET_VCA_POINT struRuleLocation; //线圈规则的中心点位置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }



}
