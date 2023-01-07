using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道解码器(云台)参数配置(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODERCFG_V30
    {
        public uint dwSize;
        public uint dwBaudRate;//波特率(bps)，0－50，1－75，2－110，3－150，4－300，5－600，6－1200，7－2400，8－4800，9－9600，10－19200， 11－38400，12－57600，13－76800，14－115.2k;
        public byte byDataBit;// 数据有几位 0－5位，1－6位，2－7位，3－8位;
        public byte byStopBit;// 停止位 0－1位，1－2位
        public byte byParity;// 校验 0－无校验，1－奇校验，2－偶校验;
        public byte byFlowcontrol;// 0－无，1－软流控,2-硬流控
        public ushort wDecoderType;//解码器类型, 从0开始，对应ptz协议列表
        public ushort wDecoderAddress;/*解码器地址:0 - 255*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_PRESET_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetPreset;/* 预置点是否设置,0-没有设置,1-设置*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CRUISE_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetCruise;/* 巡航是否设置: 0-没有设置,1-设置 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TRACK_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetTrack;/* 轨迹是否设置,0-没有设置,1-设置*/
    }

}
