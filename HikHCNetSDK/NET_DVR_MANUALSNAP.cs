using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //手动触发参数
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MANUALSNAP
    {
        public byte byOSDEnable;
        public byte byLaneNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 22, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
