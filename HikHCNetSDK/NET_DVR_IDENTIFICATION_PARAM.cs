using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /************************************end******************************************/
    //NAS认证配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IDENTIFICATION_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;        /* 用户名 32*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;        /* 密码 16*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;   //保留
    }
}
