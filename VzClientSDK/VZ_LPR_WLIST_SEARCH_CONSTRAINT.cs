using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 查找数据条件
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct VZ_LPR_WLIST_SEARCH_CONSTRAINT
    {
        /// <summary>
        /// 查找的字段
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string key;
        /// <summary>
        /// 查找的字符串
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string search_string;
    }
}
