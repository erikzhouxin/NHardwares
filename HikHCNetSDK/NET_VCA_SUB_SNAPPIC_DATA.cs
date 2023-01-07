using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_SUB_SNAPPIC_DATA
    {
        public uint dwFacePicID; //人脸图ID
        public uint dwFacePicLen;  //人脸图数据长度
        public NET_DVR_TIME struSnapTime;  //抓拍时间
        public uint dwSimilarity; //相似度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_FACE_PIC_LEN)]
        public string sPicBuf;  //图片数据
    }
}
