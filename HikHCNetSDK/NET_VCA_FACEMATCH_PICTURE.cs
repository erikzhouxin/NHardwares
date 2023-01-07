using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACEMATCH_PICTURE
    {
        public uint dwSize;             // 结构大小
        public uint dwSnapFaceLen; //抓拍人脸子图长度
        public uint dwBlockListFaceLen; //比对的禁止名单人脸子图长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              //保留字节
        public IntPtr pSnapFace;  //抓拍人脸子图的图片数据
        public IntPtr pBlockListFace;  //比对的禁止名单人脸子图数据
    }
}
