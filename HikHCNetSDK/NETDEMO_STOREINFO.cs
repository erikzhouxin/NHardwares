using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct STOREINFO
    {
        public int iMaxChannels;
        public int iDiskGroup;
        public int iStreamType;
        public bool bAnalyze;
        public bool bCycWrite;
        public uint uiFileSize;

        public CALLBACKFUN_MESSAGE funCallback;
    }
}
