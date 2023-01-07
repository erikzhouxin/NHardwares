using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRIGCOORDINATE
    {
        public ushort wTopLeftX; /*线圈左上角横坐标（2个字节）*/
        public ushort wTopLeftY; /*线圈左上角纵坐标（2个字节）*/
        public ushort wWdith; /*线圈宽度（2个字节）*/
        public ushort wHeight; /*线圈高度（2个字节）*/
    }



}
