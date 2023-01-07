using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*监视器信息，最多2048个*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_MONITORINFO
    {
        public uint dwGloalMonId; /*mon 的统一编号*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sMonName;
        public uint dwMatrixId;  /*mon所在矩阵的编号*/
        public uint dwLocalMonId; /*mon的内部编号*/
        public byte byValid;    /*是否有效，0-否，1-是*/
        public byte byTrunkType; /*使用类型，0-不作为干线使用，1-BNC，2-SP3,3-V6光纤，4-其他光纤*/
        public byte byUsedByTrunk;//当前使用状态，0-没有被使用，1-被干线使用 
        public byte byTrunkReq; /*分辨率, 以D1为单位：1- 1个D1，2- 2个D1，作为干线使用时，指的是干线的带宽*/
        public NET_DVR_TIME struInstallTime;//安装时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPurpose;/*用途描述*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
