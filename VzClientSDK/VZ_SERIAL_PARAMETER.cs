namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 串口参数
    /// </summary>
    public struct VZ_SERIAL_PARAMETER
    {
        /// <summary>
        /// 波特率 300,600,1200,2400,4800,9600,19200,34800,57600,115200
        /// </summary>
        public UInt32 uBaudRate;
        /// <summary>
        /// 校验位 其值为0-2=no,odd,even
        /// </summary>
        public UInt32 uParity;
        /// <summary>
        /// 数据位 其值为7,8 位数据位
        /// </summary>
        public UInt32 uDataBits;
        /// <summary>
        /// 停止位 其值为1,2位停止位
        /// </summary>
        public UInt32 uStopBit;         
    };
}
