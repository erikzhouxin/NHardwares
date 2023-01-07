using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ppp参数配置(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_PPPCFG_V30
    {
        public NET_DVR_IPADDR struRemoteIP;//远端IP地址
        public NET_DVR_IPADDR struLocalIP;//本地IP地址
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sLocalIPMask;//本地IP地址掩码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUsername;/* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 密码 */
        public byte byPPPMode;//PPP模式, 0－主动，1－被动
        public byte byRedial;//是否回拨 ：0-否,1-是
        public byte byRedialMode;//回拨模式,0-由拨入者指定,1-预置回拨号码
        public byte byDataEncrypt;//数据加密,0-否,1-是
        public uint dwMTU;//MTU
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PHONENUMBER_LEN)]
        public string sTelephoneNumber;//电话号码
    }

}
