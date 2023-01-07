using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EMAILCFG_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sAccount;/* 账号*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EMAIL_PWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/*密码 */

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct struSender
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sName;/* 发件人姓名 */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sAddress;/* 发件人地址 */
        }

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSmtpServer;/* smtp服务器 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPop3Server;/* pop3服务器 */

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.Struct)]
        public struReceiver[] struStringInfo;/* 最多可以设置3个收件人 */

        public byte byAttachment;/* 是否带附件 */
        public byte bySmtpServerVerify;/* 发送服务器要求身份验证 */
        public byte byMailInterval;/* mail interval */
        public byte byEnableSSL;//ssl是否启用9000_1.1
        public ushort wSmtpPort;//gmail的465，普通的为25  
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 74, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
