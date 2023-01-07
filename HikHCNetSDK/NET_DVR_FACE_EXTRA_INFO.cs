using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_EXTRA_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FACE_PIC_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_RECT[] struVcaRect;  //人脸子图坐标信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
