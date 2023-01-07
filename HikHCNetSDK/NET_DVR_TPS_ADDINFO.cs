using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //TPS附加信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_ADDINFO
    {
        public NET_DVR_LLPOS_PARAM struLLPos;//车流量最后一辆车的经纬度位置信息(byLaneState=3且byQueueLen>0时才返回)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1024, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
