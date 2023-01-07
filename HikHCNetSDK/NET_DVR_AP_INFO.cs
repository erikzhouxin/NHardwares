using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_AP_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.IW_ESSID_MAX_SIZE)]
        public string sSsid;
        public uint dwMode;/* 0 mange 模式;1 ad-hoc模式，参见NICMODE */
        public uint dwSecurity;  /*0 不加密；1 wep加密；2 wpa-psk;3 wpa-Enterprise，参见WIFISECURITY*/
        public uint dwChannel;/*1-11表示11个通道*/
        public uint dwSignalStrength;/*0-100信号由最弱变为最强*/
        public uint dwSpeed;/*速率,单位是0.01mbps*/
    }

}
