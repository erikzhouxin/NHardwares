using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 顶点定义
    /// X_1000和Y_1000的取值范围为[0, 1000]；
    /// 即位置信息为实际图像位置在整体图像位置的相对尺寸；
    /// 例如X_1000 = x*1000/win_width，其中x为点在图像中的水平像素位置，win_width为图像宽度
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_VERTEX
    {
        /// <summary>
        /// x轴
        /// </summary>
        public uint X_1000;
        /// <summary>
        /// y轴
        /// </summary>
        public uint Y_1000;
    }
}
