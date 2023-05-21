using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram
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
        public uint fileLen;
        /// <summary>
        /// 文件所在的缓存地址
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 文件CRC32校验码
        /// </summary>
        public uint fileCRC32;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram_G6
    {
        /// <summary>
        /// 节目参数文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 参数文件长度
        /// </summary>
        public uint fileLen;
        /// <summary>
        /// 文件所在的缓存地址
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 节目数据文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] dfileName;
        /// <summary>
        /// 节目数据文件类型
        /// </summary>
        public byte dfileType;
        /// <summary>
        /// 数据文件长度
        /// </summary>
        public uint dfileLen;
        /// <summary>
        /// 数据文件缓存地址
        /// </summary>
        public IntPtr dfileAddre;
    }
}
