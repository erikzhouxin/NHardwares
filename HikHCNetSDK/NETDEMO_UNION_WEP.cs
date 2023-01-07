using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UNION_WEP
    {
        public uint dwAuthentication;/*0 -开放式 1-共享式*/
        public uint dwKeyLength;/* 0 -64位；1- 128位；2-152位*/
        public uint dwKeyType;/*0 16进制;1 ASCI */
        public uint dwActive;/*0 索引：0---3表示用哪一个密钥*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.WIFI_WEP_MAX_KEY_COUNT * HikHCNetSdk.WIFI_WEP_MAX_KEY_LENGTH)]
        public string sKeyInfo;
    }

}
