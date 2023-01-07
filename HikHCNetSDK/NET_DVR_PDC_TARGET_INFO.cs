using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_TARGET_INFO
    {
        public uint dwTargetID;                 // 目标id 
        public NET_VCA_RECT struTargetRect;    // 目标框
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;      // 保留字节
    }


}
