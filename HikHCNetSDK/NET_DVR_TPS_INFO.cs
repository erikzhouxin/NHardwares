using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_INFO
    {
        public uint dwLanNum;   // 交通参数的车道数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TPS_RULE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_LANE_PARAM[] struLaneParam;
    }



}
