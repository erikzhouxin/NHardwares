using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图像增强仪
    //图像增强去燥区域配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TagIMAGEREGION
    {
        public uint dwSize;//总的结构长度
        public ushort wImageRegionTopLeftX;/* 图像增强去燥的左上x坐标 */
        public ushort wImageRegionTopLeftY;/* 图像增强去燥的左上y坐标 */
        public ushort wImageRegionWidth;/* 图像增强去燥区域的宽 */
        public ushort wImageRegionHeight;/*图像增强去燥区域的高*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
