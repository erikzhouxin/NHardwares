using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SUB_PROCIMG
    {
        public uint dwImageLen;  //图片数据长度
        public uint dwFaceScore;        //人脸评分,0-100
        public NET_VCA_RECT struVcaRect; //人脸子图区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
        public IntPtr pImage;  //图片数据
    }
}
