using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 识别区域信息定义
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_ROI_EX
    {
        /// <summary>
        /// 预留
        /// </summary>
        public byte byRes1;
        /// <summary>
        /// 是否有效
        /// </summary>
        public byte byEnable;
        /// <summary>
        /// 是否绘制
        /// </summary>
        public byte byDraw;
        /// <summary>
        /// 预留
        /// </summary>
        public byte byRes2;
        /// <summary>
        /// 预留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        /// <summary>
        /// 顶点实际个数
        /// </summary>
        public uint uNumVertex;
        /// <summary>
        /// 顶点数组
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VzClientSdk.VZ_LPRC_ROI_VERTEX_NUM_EX)]
        public VZ_LPRC_VERTEX[] struVertex;
    }
}
