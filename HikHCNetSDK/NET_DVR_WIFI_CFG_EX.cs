using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_WIFI_CFG_EX
    {
        public NET_DVR_WIFIETHERNET struEtherNet;/*wifi网口*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.IW_ESSID_MAX_SIZE)]
        public string sEssid;/*SSID*/
        public uint dwMode;/* 0 mange 模式;1 ad-hoc模式，参见*/
        public uint dwSecurity;/*0 不加密；1 wep加密；2 wpa-psk; */
        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct key
        {
            [FieldOffsetAttribute(0)]
            public UNION_WEP wep;

            [FieldOffsetAttribute(0)]
            public UNION_WPA_PSK wpa_psk;

            [FieldOffsetAttribute(0)]
            public UNION_WPA_WPA2 wpa_wpa2;//WPA-enterprise/WPA2-enterpris模式适用
        }
    }

}
