using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //读卡器参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SCANNER
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;//读卡持续时间：10-60秒
        public byte bySensitivity;//灵敏度参数，范围[1,5]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
