using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_V6SUBSYSTEMPARAM
    {
        public byte bySerialTrans;//是否透传，0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 35, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
