using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 查找范围
    /// </summary>
    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_RANGE_LIMIT
    {
        /// <summary>
        /// 查找起始位置
        /// </summary>
        public int startIndex;
        /// <summary>
        /// 查找条数
        /// </summary>
        public int count;      
    }
}
