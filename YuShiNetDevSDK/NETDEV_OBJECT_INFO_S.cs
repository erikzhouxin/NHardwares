using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVObjectInfo
     * @brief 目标信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_INFO_S
    {
        public UInt32 udwFaceNum;                                    /* 人脸数量 */
        public IntPtr pstFaceInfo;              /* 人脸信息 需动态申请内存(NETDEV_FACE_STRUCT_INFO_S[]) */
        public UInt32 udwPersonNum;                                  /* 人员数量 */
        public IntPtr pstPersonInfo;          /* 人员信息 需动态申请内存(NETDEV_PERSON_STRUCT_INFO_S[]) */
        public UInt32 udwNonMotorVehNum;                             /* 非机动车数量 */
        public IntPtr pstNonMotorVehInfo;     /* 非机动车信息 需动态申请内存(NETDEV_NON_MOTOR_VEH_INFO_S[]) */
        public UInt32 udwVehicleNum;                                 /* 车辆数量 */
        public IntPtr pstVehInfo;                       /* 车辆信息 需动态申请内存(NETDEV_VEH_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
