using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 加密信息
    /// </summary>
    public struct VZ_EMS_INFO
    {
        /// <summary>
        /// 加密ID
        /// </summary>
        public UInt32 uId;   
        /// <summary>
        /// 加密名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.ENCRYPT_NAME_LENGTH)]
        public string sName;  //加密名
    }
}
