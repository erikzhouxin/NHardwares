using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_BASIC_INFO_S
    {
        public NETDEV_IPADDR_INFO_S stDevAddr;
        public NETDEV_USER_SIMPLE_INFO_S stDevUserInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szDevName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 516)]
        public string szDevDesc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szDevModel;
        public Int32 dwDevID;
        public Int32 dwDevStatus;                                      /* See NETDEV_DEVICE_STATUS_E */
        public Int32 dwDevType;                                        /* See NETDEV_DEVICE_MAIN_TYPE_E */
        public Int32 dwDevSubType;                                     /* See NETDEV_DEVICE_SUB_TYPE_E */
        public Int32 dwOrgID;
        public Int32 dwAccessProtocol;
        public Int32 dwAccessMode;                                     /* See NETDEV_DEVICE_ACCESS_MODE_E*/
        public Int32 dwServerID;
        public Int32 dwAudioResID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string szVIIDCode;
        public Int32 dwVIIDStatus;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szSerialNum;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public string szSoftVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public string szMacAddr;
        public Int32 dwStoreStatus;
        public NETDEV_ONVIF_INFO_S stOnvifInfo;
        public NETDEV_GBINFO_S stGBInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
