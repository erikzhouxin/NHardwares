using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetDirBlock_G56
    {
        /// <summary>
        /// 要获取的文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 返回有多少个文件
        /// </summary>
        public ushort fileNumber;
        /// <summary>
        /// 返回文件列表地址
        /// </summary>
        public IntPtr dataAddre;
    }
}
