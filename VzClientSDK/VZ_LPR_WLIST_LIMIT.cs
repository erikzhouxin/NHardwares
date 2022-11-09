using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 查找条数限制
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPR_WLIST_LIMIT
    {
        /// <summary>
        /// VZ_LPR_WLIST_LIMIT_TYPE->Anonymous_988ed792_488c_49e0_9b97_4fef91401704
        /// 查找条数限制
        /// </summary>
        public VZ_LPR_WLIST_LIMIT_TYPE limitType;
        /// <summary>
        /// VZ_LPR_WLIST_RANGE_LIMIT*
        /// 查找哪一段数据
        /// </summary>
        public System.IntPtr pRangeLimit;
    }
}
