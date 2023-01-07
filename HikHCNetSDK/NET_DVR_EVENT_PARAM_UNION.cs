using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EVENT_PARAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] uLen;         // 联合体大小为12字节
        public uint dwHumanIn;      //有无人接近 0 - 无人 1- 有人  
        public float fCrowdDensity;  // 人员聚集值
    }



}
