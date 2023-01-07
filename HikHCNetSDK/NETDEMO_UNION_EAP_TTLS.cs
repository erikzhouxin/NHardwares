using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_EAP_TTLS
    {
        public byte byEapolVersion; //EAPOL版本，0-版本1，1-版本2
        public byte byAuthType; //内部认证方式，0-PAP，1-MSCHAPV2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnonyIdentity; //匿名身份
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUserName; //用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassword; //密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    } //WPA-enterprise/WPA2-enterpris模式适用

}
