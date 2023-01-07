using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CERT_PARAM
    {
        public uint dwSize;
        public ushort wCertFunc; //证书种类，0-802.1x,1-HTTPS
        public ushort wCertType; //证书类型，0-CA，1-Certificate,2-私钥文件
        public byte byFileType; //证书文件类型，0-PEM,1-PFX
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 35, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
