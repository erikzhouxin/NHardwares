using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //RS232串口参数配置(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_RS232
    {
        public uint dwBaudRate;/*波特率(bps)，0－50，1－75，2－110，3－150，4－300，5－600，6－1200，7－2400，8－4800，9－9600，10－19200， 11－38400，12－57600，13－76800，14－115.2k;*/
        public byte byDataBit;/* 数据有几位 0－5位，1－6位，2－7位，3－8位 */
        public byte byStopBit;/* 停止位 0－1位，1－2位 */
        public byte byParity;/* 校验 0－无校验，1－奇校验，2－偶校验 */
        public byte byFlowcontrol;/* 0－无，1－软流控,2-硬流控 */
        public uint dwWorkMode; /* 工作模式，0－232串口用于PPP拨号，1－232串口用于参数控制，2－透明通道 */
    }

}
