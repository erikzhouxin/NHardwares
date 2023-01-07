using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR视频输出(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOOUT_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VIDEOOUT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VOOUT[] struVOOut;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VGA_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VGAPARA[] struVGAPara;/* VGA参数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_MATRIXOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIXPARA_V30[] struMatrixPara;/* MATRIX参数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
