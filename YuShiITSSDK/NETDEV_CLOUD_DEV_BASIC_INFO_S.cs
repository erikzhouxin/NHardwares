using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CLOUD_DEV_BASIC_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_IPV4_LEN_MAX)]
        public string szIPAddr;                                                              /* IP Device IP */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_USERNAME_LEN_260)]
        public string szDevUserName;                                                         /* Device username */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEMO.NETDEV_LEN_260)]
        public byte[] szDevName;    /** Device name */

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_MODEL_LEN_64)]
        public string szDevModel;                                                            /* Device model */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_SERIAL_NUMBER_LEN_64)]
        public string szDevSerialNum;                                                        /* Device serial number */
        public Int32 dwOrgID;                                                               /* ID Home organization ID */
        public Int32 dwDevPort;                                                             /* Device port */
        public Int32 dwDevID;                                                                 /* device ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_260)]
        public string szDevSubName;                                                          /* Device aliases */
        public Int32 dwDevType;                                                               /* Device type, see enumeration #NETDEV_CLOUD_DEVICE_TYPE */
        public Int32 bKeepLiveStatus;                                                        /* If TRUE, the device is online, otherwise it's not. */
        public Int32 bIsShareDev;                                                            /* If TRUE, it's a shared device, otherwise it's not. */
        public Int32 dwValidityShareTime;                                                     /* Term of validity */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_260)]
        public string szShareDevUserName;                                                       /* Share Device User Name */
        public Int32 dwConnectMode;                                                           /* Connect Mode*/
        public Int32 dwDisTributeCloud;                                                       /* Distribution Mode  see NETDEV_DISTRIBUTE_CLOUD_SRV_E*/
        public Int32 dwCloudStorageType;                                                      /* Cloud Storage Type see NETDEV_CLOUD_STORAGE_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
        public string byRes;                                                                 /* Reserved */
    }

}
