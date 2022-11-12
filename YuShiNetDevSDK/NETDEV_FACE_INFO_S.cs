using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVFaceInfo
    * @brief 人脸信息结果
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_INFO_S
    {
        public UInt32 udwFaceID;           /* 人员ID */
        public UInt32 udwResultCode;       /* 处理结果状态码，详见#NETDEV_PERSON_RESULT_CODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;          /* 保留字节 */
    }

}
