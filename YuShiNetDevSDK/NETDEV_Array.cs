using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_Array
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_SCREEN_INFO_COLUMN)]
        public Int16[] wTemp;
    }

}
