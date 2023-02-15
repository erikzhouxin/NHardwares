using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetDirBlock_G56
    {
        public byte fileType;   //要获取的文件类型
        public ushort fileNumber; //返回有多少个文件
        public IntPtr dataAddre;  //返回文件列表地址
    }
}
