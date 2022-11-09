using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 码率类型
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_RATE_TYPE
    {
        /// <summary>
        /// 码率值
        /// </summary>
        public int rate_type_value;
        /// <summary>
        /// 码率内容
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string rate_type_content;
    }
}
