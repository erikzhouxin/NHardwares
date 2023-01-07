using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_NORMAL_FIND
    {
        public uint dwImageID; //大图ID
        public uint dwFaceScore;  //人脸评分
        public NET_VCA_RECT struVcaRect; //人脸子图区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
