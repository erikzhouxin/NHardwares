using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_V51
    {
        public uint dwSize;  //结构体大小
        public uint dwMaxUserNum; //设备支持的最大用户数-只读
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_USERNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_USER_INFO_V51[] struUser;  /* 用户参数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sloginPassword;          /* 登陆密码确认 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 240, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }

}
