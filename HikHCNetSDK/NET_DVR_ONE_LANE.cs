using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单个车道
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_LANE
    {
        public byte byEnable;  //车道是否启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;      // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLaneName;       // 车道规则名称
        public NET_DVR_DIRECTION struFlowDirection;// 车道内车流方向
        public NET_VCA_POLYGON struPolygon;     // 车道区域
    }



}
