using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR用户参数(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_V40
    {
        public uint dwSize;  //结构体大小
        public uint dwMaxUserNum; //设备支持的最大用户数-只读
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_USERNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_USER_INFO_V40[] struUser;  /* 用户参数 */
    }

}
