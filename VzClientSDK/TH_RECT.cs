using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 矩形
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TH_RECT
    {
        /// <summary>
        /// 左
        /// </summary>
        public int left;
        /// <summary>
        /// 上
        /// </summary>
        public int top;
        /// <summary>
        /// 右
        /// </summary>
        public int right;
        /// <summary>
        /// 下
        /// </summary>
        public int bottom;
    }
}
