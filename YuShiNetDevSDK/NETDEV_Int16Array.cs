using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEV_Int16Array
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_SCREEN_INFO_COLUMN)]
        public Int16[] data;
    }

}
