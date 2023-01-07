using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //L/F目标跟踪结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LF_TRACK_TARGET_INFO
    {
        public uint dwTargetID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
