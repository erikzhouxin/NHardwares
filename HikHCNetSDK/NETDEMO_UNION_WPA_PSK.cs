using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_WPA_PSK
    {
        public uint dwKeyLength;/*8-63个ASCII字符*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.WIFI_WPA_PSK_MAX_KEY_LENGTH)]
        public string sKeyInfo;
        public byte byEncryptType;/*WPA/WPA2模式下加密类型,0-AES, 1-TKIP*/
    }

}
