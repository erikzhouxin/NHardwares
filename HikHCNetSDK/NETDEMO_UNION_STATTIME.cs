using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_STATTIME
    {
        public NET_DVR_TIME tmStart; // 统计起始时间 
        public NET_DVR_TIME tmEnd;  //  统计结束时间 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 92, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
