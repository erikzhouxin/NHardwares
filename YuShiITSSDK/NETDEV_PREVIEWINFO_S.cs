using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PREVIEWINFO_S
    {
        public Int32 dwChannelID;                    /* ID  Channel ID */
        public Int32 dwStreamType;                   /* #NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwLinkMode;                     /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                      /* Play window handle */
        public Int32 dwFluency;                      /* #NETDEV_PICTURE_FLUENCY_E  image play fluency*/
        public Int32 dwStreamMode;                   /* #NETDEV_STREAM_MODE_E  start stream mode see #NETDEV_STREAM_MODE_E*/
        public Int32 dwLiveMode;                     /* #NETDEV_PULL_STREAM_MODE_E  Rev. Flow pattern */
        public Int32 dwDisTributeCloud;              /* #NETDEV_DISTRIBUTE_CLOUD_SRV_E distribution  */
        public Int32 dwallowDistribution;                    /* allow or no distribution*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 244)]
        public byte[] szReserve;                    /* Reserved */
    }

}
