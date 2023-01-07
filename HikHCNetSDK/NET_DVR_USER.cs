using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR用户参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_USERNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_USER_INFO[] struUser;
    }

}
