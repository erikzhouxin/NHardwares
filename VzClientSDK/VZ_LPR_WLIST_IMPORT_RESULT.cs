using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 导入结果
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_IMPORT_RESULT
    {
        /// <summary>
        /// 结果
        /// </summary>
        public int ret;
        /// <summary>
        /// 错误代码
        /// </summary>
        public int error_code;
    }
}
