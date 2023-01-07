using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IO输出配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IO_OUTCFG
    {
        public uint dwSize;
        public byte byDefaultStatus;//IO默认状态：0-低电平，1-高电平 
        public byte byIoOutStatus;//IO起效时状态：0-低电平，1-高电平，2-脉冲
        public ushort wAheadTime;//输出IO提前时间，单位us
        public uint dwTimePluse;//脉冲间隔时间，单位us
        public uint dwTimeDelay;//IO有效持续时间，单位us
        public byte byFreqMulti;        //倍频，数值范围[1,15]
        public byte byDutyRate;     //占空比，[0,40%]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
