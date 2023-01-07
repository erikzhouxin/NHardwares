using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FD_PROCIMG_RESULT
    {
        public uint dwSize;   //结构大小
        public uint dwImageId; //大图ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
        public uint dwSubImageNum;  //人脸子图张数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TARGET_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_SUB_PROCIMG[] struProcImg;  //单张子图信息
    }
}
