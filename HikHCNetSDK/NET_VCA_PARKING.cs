using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //停车参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PARKING
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;//触发停车报警持续时间：1-120秒，建议10秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
