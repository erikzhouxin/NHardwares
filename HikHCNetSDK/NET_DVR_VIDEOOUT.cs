using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR视频输出
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOOUT
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VIDEOOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VOOUT[] struVOOut;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VGA, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VGAPARA[] struVGAPara;   /* VGA参数 */
        public NET_DVR_MATRIXPARA struMatrixPara;/* MATRIX参数 */
    }

}
