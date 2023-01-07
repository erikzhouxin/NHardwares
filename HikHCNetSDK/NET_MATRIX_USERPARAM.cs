using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //最多256个用户，1～256
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_USERPARAM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;
        public byte byRole;/*用户角色:0-管理员,1-操作员；只有一个系统管理员，255个操作员*/
        public byte byLevel;  /*统一级别，用于操作级别管理,1- 255*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
