using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileCRC16_G56
    {
        /// <summary>
        /// 文件地址指針
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 文件长度
        /// </summary>
        public ushort fileLen;
        /// <summary>
        /// 文件CRC16校验
        /// </summary>
        public ushort fileCRC16;
    }
}
