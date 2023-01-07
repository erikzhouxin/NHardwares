using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //RS232串口参数配置(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RS232CFG_V30
    {
        public uint dwSize;
        public NET_DVR_SINGLE_RS232 struRs232;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 84, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_PPPCFG_V30 struPPPConfig;
    }

}
