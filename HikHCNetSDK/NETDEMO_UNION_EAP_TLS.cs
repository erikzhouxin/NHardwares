using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_EAP_TLS
    {
        public byte byEapolVersion; //EAPOL版本，0-版本1，1-版本2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byIdentity; //身份
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPrivateKeyPswd; //私钥密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 76, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
