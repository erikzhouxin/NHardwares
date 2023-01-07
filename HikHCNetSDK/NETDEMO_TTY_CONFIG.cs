using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2007-12-22
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TTY_CONFIG
    {
        public byte baudrate;/* 波特率 */
        public byte databits;/* 数据位 */
        public byte stopbits;/* 停止位 */
        public byte parity;/* 奇偶校验位 */
        public byte flowcontrol;/* 流控 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
