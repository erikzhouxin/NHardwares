using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //pppoe结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_PPPOECFG
    {
        public uint dwPPPOE;//0-不启用,1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPPPoEUser;//PPPoE用户名
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sPPPoEPassword;// PPPoE密码
        public NET_DVR_IPADDR struPPPoEIP;//PPPoE IP地址
    }
}
