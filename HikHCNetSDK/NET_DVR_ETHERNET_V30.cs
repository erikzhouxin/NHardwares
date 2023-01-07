using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*网络数据结构(子结构)(9000扩展)*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ETHERNET_V30
    {
        public NET_DVR_IPADDR struDVRIP;//DVR IP地址
        public NET_DVR_IPADDR struDVRIPMask;//DVR IP地址掩码
        public uint dwNetInterface;//网络接口：1-10MBase-T；2-10MBase-T全双工；3-100MBase-TX；4-100M全双工；5-10M/100M/1000M自适应；6-1000M全双工
        public ushort wDVRPort;//端口号
        public ushort wMTU;//增加MTU设置，默认1500。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;// 物理地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
