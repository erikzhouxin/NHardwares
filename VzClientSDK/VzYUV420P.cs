using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VzYUV420P
    {
        /// <summary>
        /// 
        /// </summary>
        public IntPtr pY;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr pU;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr pV;
        /// <summary>
        /// 
        /// </summary>
        public int widthStepY;
        /// <summary>
        /// 
        /// </summary>
        public int widthStepU;
        /// <summary>
        /// 
        /// </summary>
        public int widthStepV;
        /// <summary>
        /// 
        /// </summary>
        public int width;
        /// <summary>
        /// 
        /// </summary>
        public int height;
    }
}
