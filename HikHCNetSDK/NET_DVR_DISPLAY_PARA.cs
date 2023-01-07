using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //硬解码显示区域参数(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPLAY_PARA
    {
        public int bToScreen;
        public int bToVideoOut;
        public int nLeft;
        public int nTop;
        public int nWidth;
        public int nHeight;
        public int nReserved;
    }

}
