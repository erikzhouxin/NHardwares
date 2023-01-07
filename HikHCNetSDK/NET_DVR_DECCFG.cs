using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*整个设备解码配置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECCFG
    {
        public uint dwSize;
        public uint dwDecChanNum;/*解码通道的数量*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DECNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DECINFO[] struDecInfo;
    }
}
