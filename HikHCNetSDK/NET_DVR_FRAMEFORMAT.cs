using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ATM参数
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_FRAMEFORMAT
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sATMIP;/* ATM IP地址 */
        public uint dwATMType;/* ATM类型 */
        public uint dwInputMode;/* 输入方式	0-网络侦听 1-网络接收 2-串口直接输入 3-串口ATM命令输入*/
        public uint dwFrameSignBeginPos;/* 报文标志位的起始位置*/
        public uint dwFrameSignLength;/* 报文标志位的长度 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byFrameSignContent;/* 报文标志位的内容 */
        public uint dwCardLengthInfoBeginPos;/* 卡号长度信息的起始位置 */
        public uint dwCardLengthInfoLength;/* 卡号长度信息的长度 */
        public uint dwCardNumberInfoBeginPos;/* 卡号信息的起始位置 */
        public uint dwCardNumberInfoLength;/* 卡号信息的长度 */
        public uint dwBusinessTypeBeginPos;/* 交易类型的起始位置 */
        public uint dwBusinessTypeLength;/* 交易类型的长度 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_FRAMETYPECODE[] frameTypeCode;/* 类型 */
    }
}
