using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FINDDATA_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String szFileName;               /* Recording file name */
        public Int64 tBeginTime;                                    /* Start time */
        public Int64 tEndTime;                                      /* End time */
        public byte byFileType;                                     /* Recording storage type */
        public UInt32 udwServerID;                                /* 录像所属服务器ID */
        public UInt32 udwFileSize;                                /* Recording file size */
        public Int32 dwFileType;                                 /* 文件类型，参考# NETDEV_RECORD_SEARCH_TYPE_E ，暂内部使用 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 159)]
        public byte[] szReserve;                    /* Reserved */
    }

}
