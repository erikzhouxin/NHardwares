using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeTemplate
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;
        public Int32 dwTamplateID;
    }

}
