using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 分辨率
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_RESOLUTION
    {
        /// <summary>
        /// 码流类型
        /// </summary>
        public int resolution_type;
        /// <summary>
        /// 码流类型
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string resolution_content;
    }
}
