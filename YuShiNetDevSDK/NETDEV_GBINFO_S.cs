using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GBINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szUniCode;      /* 国标资源编码，范围[1, 32]*/
        public Int32 udwTransport;                  /* 传输模式 0: TCP 1: UDP*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                      /* 保留字节 */
    };

}
