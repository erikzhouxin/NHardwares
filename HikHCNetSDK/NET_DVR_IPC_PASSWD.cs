using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPC_PASSWD
    {
        public uint dwSize;    //结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sOldPasswd;  //IPC的旧密码，传给DVR让DVR验证
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sNewPasswd;  //IPC的新密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
