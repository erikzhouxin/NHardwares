using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PICMODEL_RESULT
    {
        public uint dwImageLen;  //图片数据长度
        public uint dwModelLen;  //模型数据长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
        public IntPtr pImage;  //人脸图片数据指针
        public IntPtr pModel;  //模型数据指针
    }
}
