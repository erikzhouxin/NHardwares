using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileAttribute_G56
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 文件长度
        /// </summary>
        public int fileLen;
        /// <summary>
        /// 文件CRC校验
        /// </summary>
        public int fileCRC;
    }
}
