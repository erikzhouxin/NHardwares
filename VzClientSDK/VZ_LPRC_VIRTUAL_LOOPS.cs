using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 虚拟线圈序列
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_VIRTUAL_LOOPS
    {
        /// <summary>
        /// 实际个数
        /// </summary>
        public uint uNumVirtualLoop;
        /// <summary>
        /// 虚拟线圈
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = VzClientSdk.VZ_LPRC_VIRTUAL_LOOP_MAX_NUM)]
        public VZ_LPRC_VIRTUAL_LOOP[] struLoop;
    }
}
