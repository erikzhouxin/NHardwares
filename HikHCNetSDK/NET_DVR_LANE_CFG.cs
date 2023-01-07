using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车道配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LANE_CFG
    {
        public uint dwSize; // 结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LANE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_LANE[] struLane; // 车道参数 数组下标作为车道ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    // 保留字节
    }



}
