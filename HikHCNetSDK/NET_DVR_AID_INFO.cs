using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通事件信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AID_INFO
    {
        public byte byRuleID;   // 规则序号，为规则配置结构下标，0-16
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName; //  规则名称
        public uint dwAIDType;  // 报警事件类型
        public NET_DVR_DIRECTION struDirect; // 报警指向区域  
        public byte bySpeedLimit; //限速值，单位km/h[0,255]
        public byte byCurrentSpeed; //当前速度值，单位km/h[0,255]
        public byte byVehicleEnterState;//车辆出入状态 0-无效 1-驶入 2-驶出
        public byte byState; //0-变化上传，1-轮巡上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byParkingID; //停车位编号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;  // 保留字节 
    }



}
