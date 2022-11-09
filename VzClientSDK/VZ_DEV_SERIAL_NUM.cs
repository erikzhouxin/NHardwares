using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 设备序列号
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_DEV_SERIAL_NUM
    {
        /// <summary>
        /// 高位
        /// </summary>
        public uint uHi;
        /// <summary>
        /// 低位
        /// </summary>
        public uint uLo;
    }
}
