using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CERT_INFO
    {
        public uint dwSize;
        public NET_DVR_CERT_PARAM struCertParam;    //证书参数
        public uint dwValidDays;   //有效天数，类型为自签名时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPasswd;   //私钥密码
        public NET_DVR_CERT_NAME struCertName;    // 证书名称
        public NET_DVR_CERT_NAME struIssuerName;    // 证书发行者名称（自签名证书信息获取时有效）
        public NET_DVR_TIME_EX struBeginTime;   //证书创建时间（自签名证书信息获取时有效）
        public NET_DVR_TIME_EX struEndTime;   //证书截止时间（自签名证书信息获取时有效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] serialNumber;   //证书标识码（自签名证书信息获取时有效）
        public byte byVersion;
        public byte byKeyAlgorithm;         //加密类型 0-RSA  1-DSA
        public byte byKeyLen;               //加密长度 0-512  1-1024、 2-2048
        public byte bySignatureAlgorithm; //签名算法类型（自签名证书信息获取时有效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
