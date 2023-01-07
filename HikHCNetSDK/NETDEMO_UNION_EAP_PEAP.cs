using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_EAP_PEAP
    {
        public byte byEapolVersion; //EAPOL版本，0-版本1，1-版本2
        public byte byAuthType; //内部认证方式，0-GTC，1-MD5，2-MSCHAPV2
        public byte byPeapVersion; //PEAP版本，0-版本0，1-版本1
        public byte byPeapLabel; //PEAP标签，0-老标签，1-新标签
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
