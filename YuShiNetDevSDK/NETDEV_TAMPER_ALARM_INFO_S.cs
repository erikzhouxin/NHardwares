using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TAMPER_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                               /* Sensitivity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                       /* Reserved */
    }

}
