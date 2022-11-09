using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 当前识别结果加密类型
    /// </summary>
    public struct VZ_LPRC_ACTIVE_ENCRYPT
    {
        /// <summary>
        /// 当前加密类型ID
        /// </summary>
        public UInt32 uActiveID;
        /// <summary>
        /// 系统加密类型
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VzClientSdk.ENCRYPT_LENGTH)]
        public VZ_EMS_INFO[] oEncrpty;
        /// <summary>
        /// 系统加密类型长度
        /// </summary>
        public UInt32 uSize;
        /// <summary>
        /// 签名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.SIGNATURE_LENGTH)]
        public string signature;
    }
}
