using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szName;                                           /* Boolean name */
        public Int32 dwChancelId;                                       /* Channel number */
        public Int32 enDefaultStatus;                                   /* Default status of boolean output, see enumeration #NETDEV_BOOLEAN_MODE_E */
        public Int32 dwDurationSec;                                     /* Alarm duration (s) */
        public Int32 dwOutputNum;                                       /* Alarm output serial number */
    }

}
