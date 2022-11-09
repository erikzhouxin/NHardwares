using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 加载条件
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_LOAD_CONDITIONS
    {
        /// <summary>
        /// VZ_LPR_WLIST_SEARCH_WHERE*
        /// 查找条件
        /// </summary>
        public System.IntPtr pSearchWhere;

        /// <summary>
        /// VZ_LPR_WLIST_LIMIT*
        /// 查找条数限制
        /// </summary>
        public System.IntPtr pLimit;

        /// <summary>
        /// VZ_LPR_WLIST_SORT_TYPE*
        /// 结果的排序方式，为空表示按默认排序
        /// </summary>
        public System.IntPtr pSortType;
    }
}
