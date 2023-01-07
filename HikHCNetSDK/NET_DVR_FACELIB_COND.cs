using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //导入人脸数据(人脸图片+图片附件信息)到人脸库的条件参数结构体。
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACELIB_COND
    {
        public uint dwSize;             // 结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_MAX_FDID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] szFDID;
        public byte byConcurrent;//设备并发处理：0- 不开启，1- 开始 
        public byte byCover;//是否覆盖式导入 0-否，1-是
        public byte byCustomFaceLibID;//FDID是否是自定义，0-不是，1-是；
        public byte byPictureSaveMode;//上传原图保存模式，0-保存，1-不保存;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byIdentityKey;//交互操作口令
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
