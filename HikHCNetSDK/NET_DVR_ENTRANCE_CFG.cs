using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //出入口控制参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ENTRANCE_CFG
    {
        public uint dwSize;
        public byte byEnable;
        public byte byBarrierGateCtrlMode;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public uint dwRelateTriggerMode;
        public uint dwMatchContent;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RELAY_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_RELAY_PARAM[] struRelayRelateInfo;//继电器关联配置信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IOIN_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byGateSingleIO;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VEHICLE_TYPE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VEHICLE_CONTROL[] struVehicleCtrl;//车辆信息管控
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留
    }
}
