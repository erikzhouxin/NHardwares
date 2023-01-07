using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_MESSAGE
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.INQUEST_MESSAGE_LEN)]
        public string sMessage; //重点标记信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 46, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                     //保留
    }
}
