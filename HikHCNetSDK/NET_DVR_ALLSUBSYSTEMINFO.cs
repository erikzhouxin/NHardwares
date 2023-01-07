using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALLSUBSYSTEMINFO
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SUBSYSTEM_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SUBSYSTEMINFO[] struSubSystemInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
