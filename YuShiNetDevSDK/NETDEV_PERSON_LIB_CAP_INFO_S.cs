using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPersonLibCapInfo
     * @brief 人脸库容量信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_LIB_CAP_INFO_S
    {
        public UInt32 udwLibID;            /* 库ID */
        public UInt32 udwCapacity;         /* 库容量信息，单位：人 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;          /* 保留字段 */
    }

}
