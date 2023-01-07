using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交易信息
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_TRADEINFO
    {
        public ushort m_Year;
        public ushort m_Month;
        public ushort m_Day;
        public ushort m_Hour;
        public ushort m_Minute;
        public ushort m_Second;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] DeviceName;//设备名称
        public uint dwChannelNumer;//通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] CardNumber;//卡号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string cTradeType;//交易类型
        public uint dwCash;//交易金额
    }
}
