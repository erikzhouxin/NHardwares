using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 时间区间
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_TM_RANGE
    {

        /// <summary>
        /// VZ_TM->Anonymous_40d76b6c_816a_4821_a5db_3480cee2a116
        /// 开始时间
        /// </summary>
        public VZ_TM struTimeStart;

        /// <summary>
        /// VZ_TM->Anonymous_40d76b6c_816a_4821_a5db_3480cee2a116
        /// 结束时间
        /// </summary>
        public VZ_TM struTimeEnd;
    }
}
