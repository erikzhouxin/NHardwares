using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_WPA_WPA2
    {
        public byte byEncryptType;  /*加密类型,0-AES, 1-TKIP*/
        public byte byAuthType; //认证类型，0-EAP_TTLS,1-EAP_PEAP,2-EAP_TLS
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public WIFI_AUTH_PARAM auth_param;
    }

}
