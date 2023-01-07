using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_VICOLOR
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_COLOR[] struColor;/*图象参数(第一个有效，其他三个保留)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struHandleTime;/*处理时间段(保留)*/
    }
}
