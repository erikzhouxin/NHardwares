using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 结果的排列方式
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct VZ_LPR_WLIST_SORT_TYPE
    {
        /// <summary>
        /// 排序的字段
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string key;

        /// <summary>
        /// VZ_LPR_WLIST_SORT_DIRECTION->Anonymous_dde74036_93c7_4601_966c_0439d47c4836
        /// 排序的方式
        /// </summary>
        public VZ_LPR_WLIST_SORT_DIRECTION direction;
    }
}
