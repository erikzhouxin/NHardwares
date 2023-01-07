using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_PIC
    {
        public uint dwSize;   //结构大小
        public uint dwFacePicNum;  //人脸图个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HUMAN_PICTURE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_PICMODEL_RESULT[] struBlockListPic;  //单张照片信息
    }
}
