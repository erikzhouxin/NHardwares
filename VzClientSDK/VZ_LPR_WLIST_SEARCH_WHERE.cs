using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 查找条件
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_SEARCH_WHERE
    {

        /// <summary>
        /// VZ_LPR_WLIST_SEARCH_TYPE->Anonymous_e3b38339_d7de_4d6d_998f_8f03f1a82e9c
        /// 查找的方式，如果是完全匹配，每个条件之间为与;是包含字符时，每个条件之间为或
        /// </summary>
        public VZ_LPR_WLIST_SEARCH_TYPE searchType;

        /// <summary>
        /// 查找条件个数，为0表示没有搜索条件
        /// </summary>
        public uint searchConstraintCount;

        /// <summary>
        /// VZ_LPR_WLIST_SEARCH_CONSTRAINT*
        /// 查找条件数组指针
        /// </summary>
        public System.IntPtr pSearchConstraints;
    }
}
