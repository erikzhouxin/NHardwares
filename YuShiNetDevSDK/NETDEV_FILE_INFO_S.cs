using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVFileInfo
    * @brief 文件信息
    * @attention 若udwSize不为0且pcData为空,则通过szUrl获取图片
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szName;   /* 文件名称 范围[1, 16]*/
        public UInt32 udwSize;                 /* 文件大小[data或通过szurl获取到的图片大小(Base64编码后)] */
        public UInt32 dwFileType;              /* 文件类型，详见枚举值：NETDEV_FILE_TYPE_E */
        public UInt32 udwLastChange;           /* 最后修改时间，UTC时间，单位为s */
        public IntPtr pcData;                 /* 文件数据 Base64 需根据udwSize 动态申请内存(CHAR*)*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_512)]
        public string szUrl;   /* 图片URL，长度范围[0,256] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字节 */
    }

}
