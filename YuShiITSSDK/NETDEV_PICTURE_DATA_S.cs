using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PICTURE_DATA_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] pucData;                /* pucData[0]: Y plane pointer, pucData[1]: U plane pointer, pucData[2]: V plane pointer */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Int32[] dwLineSize;              /* ulLineSize[0]: Y line spacing, ulLineSize[1]: U line spacing, ulLineSize[2]: V line spacing */
        public Int32 dwPicHeight;                /* Picture height */
        public Int32 dwPicWidth;                 /* Picture width */
        public Int32 dwRenderTimeType;           /* Time data type for rendering */
        public Int64 tRenderTime;                /* Time data for rendering */
    };

}
