using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*网络数据结构(子结构)*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_ETHERNET
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIP;//DVR IP地址
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIPMask;//DVR IP地址掩码
        public uint dwNetInterface;//网络接口 1-10MBase-T 2-10MBase-T全双工 3-100MBase-TX 4-100M全双工 5-10M/100M自适应
        public ushort wDVRPort;//端口号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;//服务器的物理地址
    }
}
