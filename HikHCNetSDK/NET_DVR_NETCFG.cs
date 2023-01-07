using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //网络配置结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_NETCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ETHERNET[] struEtherNet;/* 以太网口 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sManageHostIP;//远程管理主机地址
        public ushort wManageHostPort;//远程管理主机端口号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sIPServerIP;//IPServer服务器地址
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sMultiCastIP;//多播组地址
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sGatewayIP;//网关地址
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sNFSIP;//NFS主机IP地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNFSDirectory;//NFS目录
        public uint dwPPPOE;//0-不启用,1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPPPoEUser;//PPPoE用户名
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sPPPoEPassword;// PPPoE密码
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sPPPoEIP;//PPPoE IP地址(只读)
        public ushort wHttpPort;//HTTP端口号
    }
}
