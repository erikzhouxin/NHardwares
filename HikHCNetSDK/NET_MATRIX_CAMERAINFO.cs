using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2011-04-18
    /*摄像机信息,最多9999个，从1开始 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_CAMERAINFO
    {
        public uint dwGlobalCamId;      /* cam的全局编号*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sCamName; /*cam的名称*/
        public uint dwMatrixId;          /*cam对应矩阵的编号*/
        public uint dwLocCamId;         /*cam对应矩阵的内部编号*/
        public byte byValid;    /*是否有效，0-否，1-是*/
        public byte byPtzCtrl; /* 是否可控，0-否，1-是*/
        public byte byUseType; //*使用类型，0-不作为干线使用，1-BNC，2-SP3,3-V6光纤，4-其他光纤*/ 
        public byte byUsedByTrunk;//当前使用状态，0-没有被使用，1-被干线使用 
        public byte byTrunkReq; /*摄像机分辨率,以D1为单位：1 - 1个D1，2- 2个D1，作为干线使用时，指的是干线的带宽*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_TIME struInstallTime;//安装时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPurpose;/*用途描述*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
