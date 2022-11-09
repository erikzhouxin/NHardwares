using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 图像信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_IMAGE_INFO
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public uint uWidth;
        /// <summary>
        /// 高度
        /// </summary>
        public uint uHeight;
        /// <summary>
        /// 间距
        /// </summary>
        public uint uPitch;
        /// <summary>
        /// 像素
        /// </summary>
        public uint uPixFmt;
        /// <summary>
        /// 缓冲区
        /// </summary>
        public IntPtr pBuffer;
    }
}
