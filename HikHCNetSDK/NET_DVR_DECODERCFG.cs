using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道解码器(云台)参数配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODERCFG
    {
        public uint dwSize;
        public uint dwBaudRate; //波特率(bps)，0－50，1－75，2－110，3－150，4－300，5－600，6－1200，7－2400，8－4800，9－9600，10－19200， 11－38400，12－57600，13－76800，14－115.2k;
        public byte byDataBit; // 数据有几位 0－5位，1－6位，2－7位，3－8位;
        public byte byStopBit;// 停止位 0－1位，1－2位;
        public byte byParity; // 校验 0－无校验，1－奇校验，2－偶校验;
        public byte byFlowcontrol;// 0－无，1－软流控,2-硬流控
        public ushort wDecoderType;//解码器类型, 0－YouLi，1－LiLin-1016，2－LiLin-820，3－Pelco-p，4－DM DynaColor，5－HD600，6－JC-4116，7－Pelco-d WX，8－Pelco-d PICO
        public ushort wDecoderAddress;/*解码器地址:0 - 255*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_PRESET, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetPreset;/* 预置点是否设置,0-没有设置,1-设置*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CRUISE, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetCruise;/* 巡航是否设置: 0-没有设置,1-设置 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TRACK, ArraySubType = UnmanagedType.I1)]
        public byte[] bySetTrack;/* 轨迹是否设置,0-没有设置,1-设置*/
    }

}
