using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CREATEFILE_INFO
    {
        public int iHandle;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string strCameraid;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string strFileName;

        public BLOCKTIME tFileCreateTime;
    }
}
