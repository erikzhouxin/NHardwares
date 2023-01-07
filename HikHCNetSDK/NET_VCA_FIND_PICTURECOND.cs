using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FIND_PICTURECOND
    {
        public Int32 lChannel;//通道号
        public NET_DVR_TIME struStartTime;//开始时间
        public NET_DVR_TIME struStopTime;//结束时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
