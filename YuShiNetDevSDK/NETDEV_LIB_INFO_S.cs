using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVLibInfo
    * @brief 库信息
    * @attention 人员库和车辆库
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LIB_INFO_S
    {
        public UInt32 udwID;                           /* 库ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;          /* 库名称 范围[1,63] */
        public UInt32 udwType;                         /* 人员库类型 详情参见枚举NETDEV_PEOPLE_LIB_TYPE_E*/
        public UInt32 udwPersonNum;                    /* 库中人员信息的总数 */
        public UInt32 udwFaceNum;                      /* 库中人脸照片总数 */
        public UInt32 udwMemberNum;                    /* 库中成员的总数 */
        public UInt32 udwLastChange;                   /* 库的信息的最后修改时间 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public string szBelongIndex;   /* 库的唯一归属索引 */
        public Int32 bIsMonitored;                    /* 是否已布控，获取库信息时必带 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                      /* 保留字节 */
    }

}
