using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WIFI_CFG
    {
        public uint dwSize;
        public NET_DVR_WIFI_CFG_EX struWifiCfg;
    }

}
