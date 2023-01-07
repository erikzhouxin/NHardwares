using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //导入人脸图片数据到人脸库的结果参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_UPLOAD_FILE_RET
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_UPLOADFILE_URL_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUrl;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 260, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
