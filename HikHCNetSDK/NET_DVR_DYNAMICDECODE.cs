using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DYNAMICDECODE
    {
        public uint dwSize;
        public NET_DVR_ASSOCIATECFG struAssociateCfg;//触发动态解码关联结构
        public NET_DVR_PU_STREAM_CFG struPuStreamCfg;//动态解码结构
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
