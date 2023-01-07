using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SMART_SEARCH_RET
    {
        public NET_DVR_TIME struStartTime;  //移动侦测报警开始的时间
        public NET_DVR_TIME struEndTime;   //事件停止的时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
