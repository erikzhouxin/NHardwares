using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AP_INFO_LIST
    {
        public uint dwSize;
        public uint dwCount;/*无线AP数量，不超过20*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.WIFI_MAX_AP_COUNT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_AP_INFO[] struApInfo;
    }

}
