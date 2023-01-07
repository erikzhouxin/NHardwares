using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人流量信息查询
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_QUERY
    {
        public NET_DVR_TIME tmStart;
        public NET_DVR_TIME tmEnd;
        public uint dwLeaveNum;
        public uint dwEnterNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }


}
