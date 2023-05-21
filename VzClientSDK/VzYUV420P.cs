using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// YUV420P的帧结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VzYUV420P
    {
        /// <summary>
        /// Y信号地址
        /// </summary>
        public IntPtr pY;
        /// <summary>
        /// U信号地址
        /// </summary>
        public IntPtr pU;
        /// <summary>
        /// V信号地址
        /// </summary>
        public IntPtr pV;
        /// <summary>
        /// Y信号宽度
        /// </summary>
        public int widthStepY;
        /// <summary>
        /// U信号宽度
        /// </summary>
        public int widthStepU;
        /// <summary>
        /// V信号宽度
        /// </summary>
        public int widthStepV;
        /// <summary>
        /// 帧数据宽度
        /// </summary>
        public int width;
        /// <summary>
        /// 帧数据高度
        /// </summary>
        public int height;
    }
}
