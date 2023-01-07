using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //BONDING网卡配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_NETWORK_BONDING
    {
        public uint dwSize;
        public byte byEnable;
        public byte byNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_BOND_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_BONDING[] struOneBond;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
