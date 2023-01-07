using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //字符叠加配置条件参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_OVERLAP_CFG
    {
        public uint dwSize;
        public byte byEnable;//是否启用：0- 不启用，1- 启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//这里保留音频的压缩参数
        public NET_ITS_OVERLAP_ITEM_PARAM struOverLapItem;//字符串参数
        public NET_ITS_OVERLAP_INFO_PARAM struOverLapInfo;//字符串内容信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//这里保留音频的压缩参数 
    }
}
