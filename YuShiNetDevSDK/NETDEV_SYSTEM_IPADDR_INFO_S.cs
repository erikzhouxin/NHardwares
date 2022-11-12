using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_IPADDR_INFO_S
    {
        public string bEnabled;                      /*NTP Server enable 0:unable  1:enable */
        public Int64 ulAddressType;                 /*Address type  0:IPv4  1:IPv6(Temporary does not support)  2:domain name(NVR and AIO support)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szIPAddress;                   /* The IP address of the NTP server ,character length range [0,64]. When address type is 0,the node must be selected. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szDomainName;                  /*The domain name of the NTP server ,character length range [0,64]. When address type is 2,the node must be selected.*/

        public Int64 ulPort;                         /*NTP Port ,the range of [1-65535]. IPC does not support this configuration. */
        public Int64 ulSynchronizeInterval;          /*Synchronize Interval: The support range of NVR and VMS is 5/10/15/30 minutes ,1/2/3/6/12 hours ,1 day ,and 1 week.The support range of IPC is 30-3600 seconds.
                                                     All of the above time periods need to be converted to a time value in seconds.*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                               /* Reserved */
    };

}
