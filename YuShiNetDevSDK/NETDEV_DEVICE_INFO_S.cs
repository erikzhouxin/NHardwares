using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_INFO_S
    {
        public Int32 dwDevType;
        public Int16 wAlarmInputNum;                   /* Number of alarm inputs */
        public Int16 wAlarmOutputNum;                  /* Number of alarm outputs */
        public Int32 dwChannelNum;                      /* Number of Channels */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szReserve;
    }

}
