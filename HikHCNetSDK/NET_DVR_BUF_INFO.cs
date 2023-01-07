using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BUF_INFO
    {
        public IntPtr pBuf;
        public uint nLen;
    }
}
