using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STRUCTHEAD
    {
        public ushort wLength;  //结构长度
        public byte byVersion;  /*高低4位分别代表高低版本，后续根据版本和长度进行扩展，不同的版本的长度进行限制*/
        public byte byRes;
    }
}
