using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struMotionParam
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U2)]
        public ushort[] wMotDetChanNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 672, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            wMotDetChanNo = new ushort[HikHCNetSdk.MAX_CHANNUM_V30];
            byRes = new byte[672];
        }
    }
}
