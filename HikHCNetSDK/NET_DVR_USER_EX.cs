using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR用户参数(SDK_V15扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_EX
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_USERNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_USER_INFO_EX[] struUser;
    }

}
