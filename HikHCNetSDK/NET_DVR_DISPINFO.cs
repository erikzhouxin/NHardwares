using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示通道信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPINFO
    {
        public byte byChanNums;//通道个数
        public byte byStartChan;//起始通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SUPPORT_RES, ArraySubType = UnmanagedType.U1)]
        public uint[] dwSupportResolution;//支持的分辨率
    }
}
