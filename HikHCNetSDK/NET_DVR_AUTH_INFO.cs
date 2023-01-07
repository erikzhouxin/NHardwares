using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //认证记录（设备未实现）
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUTH_INFO
    {
        public byte byAuthResult; //认证结果：0-无效，1-认证成功，2-认证失败
        public byte byAuthType; //认证方式：0-无效，1-指纹，2-人脸
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1; //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //卡号
        public uint dwPicDataLen; //图片数据长度（当认证方式byAuthType为人脸时有效）
        public IntPtr pImage; //图片指针（当认证方式byAuthType为人脸时有效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 212, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
