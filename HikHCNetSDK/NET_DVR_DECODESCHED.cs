using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODESCHED
    {
        public NET_DVR_SCHEDTIME struSchedTime;
        public byte byDecodeType;/*0-无，1-轮询解码，2-动态解码*/
        public byte byLoopGroup;//轮询组号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_PU_STREAM_CFG struDynamicDec;//动态解码
    }

}
