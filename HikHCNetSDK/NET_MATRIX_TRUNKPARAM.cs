using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_TRUNKPARAM
    {
        public uint dwSize;
        public uint dwTrunkId;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sTrunkName;
        public uint dwSrcMonId;
        public uint dwDstCamId;
        public byte byTrunkType;  /*使用类型  1-BNC，2-SP3光纤高清，3-SP3光纤D1， 4-V6光纤，5-其他光纤*/
        public byte byAbility;     /*表示光纤的带宽，可以传输几路*/
        public byte bySubChan;   /*针对光纤干线而言，表示子通道号*/
        public byte byLevel;        /* 干线级别 1-255*/
        public ushort wReserveUserID;   //预留的用户ID： 1~256 ，0表示释放预留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
