using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************底图上传*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BASEMAP_CFG
    {
        public byte byScreenIndex;         //屏幕的序号
        public byte byMapNum;               /*被分割成了多少块*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
        public ushort wSourWidth;           /* 原图片的宽度 */
        public ushort wSourHeight;          /* 原图片的高度 */
    }
}
