using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonList
    * @brief 人员信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIST_S
    {
        public UInt32 udwPersonID;                                 /* 人员ID */
        public UInt32 udwFaceNum;                                  /* 人脸个数 批量单次最多6个 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_8)]
        public NETDEV_FACE_INFO_S[] stFaceInfo;        /* 人脸信息结果列表 */
        public UInt32 udwReqseq;                                   /* 请求数据序号,仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                  /* 保留字节 */
    }

}
