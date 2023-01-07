using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR用户参数(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_USERNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_USER_INFO_V30[] struUser;
    }

}
