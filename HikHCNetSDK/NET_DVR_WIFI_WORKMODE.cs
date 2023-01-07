using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WIFI_WORKMODE
    {
        public uint dwSize;
        public uint dwNetworkInterfaceMode;/*0 自动切换模式　1 有线模式*/
    }

}
