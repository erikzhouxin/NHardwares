using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警设备信息
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_ALARMER
    {
        public byte byUserIDValid;/* userid是否有效 0-无效，1-有效 */
        public byte bySerialValid;/* 序列号是否有效 0-无效，1-有效 */
        public byte byVersionValid;/* 版本号是否有效 0-无效，1-有效 */
        public byte byDeviceNameValid;/* 设备名字是否有效 0-无效，1-有效 */
        public byte byMacAddrValid; /* MAC地址是否有效 0-无效，1-有效 */
        public byte byLinkPortValid;/* login端口是否有效 0-无效，1-有效 */
        public byte byDeviceIPValid;/* 设备IP是否有效 0-无效，1-有效 */
        public byte bySocketIPValid;/* socket ip是否有效 0-无效，1-有效 */
        public int lUserID; /* NET_DVR_Login()返回值, 布防时有效 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;/* 序列号 */
        public uint dwDeviceVersion;/* 版本信息 高16位表示主版本，低16位表示次版本*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDeviceName;/* 设备名字 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMacAddr;/* MAC地址 */
        public ushort wLinkPort; /* link port */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] sDeviceIP;/* IP地址 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] sSocketIP;/* 报警主动上传时的socket IP地址 */
        public byte byIpProtocol; /* Ip协议 0-IPV4, 1-IPV6 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
