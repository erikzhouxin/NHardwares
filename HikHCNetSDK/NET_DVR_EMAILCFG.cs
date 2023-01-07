using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /************************************视频综合平台(end)***************************************/

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_EMAILCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sUserName;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sPassWord;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sFromName;/* Sender *///字符串中的第一个字符和最后一个字符不能是"@",并且字符串中要有"@"字符
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string sFromAddr;/* Sender address */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sToName1;/* Receiver1 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sToName2;/* Receiver2 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string sToAddr1;/* Receiver address1 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string sToAddr2;/* Receiver address2 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sEmailServer;/* Email server address */
        public byte byServerType;/* Email server type: 0-SMTP, 1-POP, 2-IMTP…*/
        public byte byUseAuthen;/* Email server authentication method: 1-enable, 0-disable */
        public byte byAttachment;/* enable attachment */
        public byte byMailinterval;/* mail interval 0-2s, 1-3s, 2-4s. 3-5s*/
    }

}
