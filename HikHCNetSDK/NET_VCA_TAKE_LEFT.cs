using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //丢包/捡包参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TAKE_LEFT
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;//触发丢包/捡包报警的持续时间：1-120秒，建议10秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
