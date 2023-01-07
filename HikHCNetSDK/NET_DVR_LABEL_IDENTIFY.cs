using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LABEL_IDENTIFY
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LABEL_IDENTIFY_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLabelIdentify;    // 64字节标识
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;               // 保留字节
    }
}
