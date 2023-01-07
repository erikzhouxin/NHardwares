using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Network Configure Structure(V50)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NETCFG_V50
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ETHERNET_V30[] struEtherNet;        //Network Port
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPADDR[] struRes1;                            /*reserve*/
        public NET_DVR_IPADDR struAlarmHostIpAddr;                    /* IP address of remote management host */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                                        /* reserve */
        public ushort wAlarmHostIpPort;                                /* Port of remote management Host */
        public byte byUseDhcp;                                      /* Whether to enable the DHCP 0xff- invalid 0- enabled 1- not enabled */
        public byte byIPv6Mode;                                        //IPv6 allocation, 0- routing announcement, 1- manually, 2- enable DHCP allocation 
        public NET_DVR_IPADDR struDnsServer1IpAddr;                    /* IP address of the domain name server 1  */
        public NET_DVR_IPADDR struDnsServer2IpAddr;                    /* IP address of the domain name server 2  */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byIpResolver;                    /* IP parse server domain name or IP address */
        public ushort wIpResolverPort;                                /* Parsing IP server port number */
        public ushort wHttpPortNo;                                    /* HTTP port number  */
        public NET_DVR_IPADDR struMulticastIpAddr;                    /* Multicast group address */
        public NET_DVR_IPADDR struGatewayIpAddr;                        /* Gateway address  */
        public NET_DVR_PPPOECFG struPPPoE;
        public byte byEnablePrivateMulticastDiscovery;                //Private multicast search, 0- default, 1- enabled, 2 - disabled 
        public byte byEnableOnvifMulticastDiscovery;                //Onvif multicast search, 0- default, 1- enabled, 2 - disabled 
        public ushort wAlarmHost2IpPort;                                /* Alarm host 2 port */
        public NET_DVR_IPADDR struAlarmHost2IpAddr;                    /* Alarm host 2 IP addresses */
        public byte byEnableDNS; //DNS Enabled, 0-close,1-open 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 599, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            struEtherNet = new NET_DVR_ETHERNET_V30[HikHCNetSdk.MAX_ETHERNET];
            struRes1 = new NET_DVR_IPADDR[2];
            struAlarmHostIpAddr = new NET_DVR_IPADDR();
            struAlarmHost2IpAddr = new NET_DVR_IPADDR();
            struDnsServer1IpAddr = new NET_DVR_IPADDR();
            struDnsServer2IpAddr = new NET_DVR_IPADDR();
            byIpResolver = new byte[HikHCNetSdk.MAX_DOMAIN_NAME];
            struMulticastIpAddr = new NET_DVR_IPADDR();
            struGatewayIpAddr = new NET_DVR_IPADDR();
            struPPPoE = new NET_DVR_PPPOECFG();
            byRes = new byte[599];
        }
    }

}
