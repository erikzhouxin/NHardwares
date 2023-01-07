using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INPUT_INTERFACE_CTRL
    {
        public byte byInputSourceType;  //见INPUT_INTERFACE_TYPE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
