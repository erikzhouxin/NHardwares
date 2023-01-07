using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSION_LIMIT
    {
        public uint dwSize;           //结构体大小
        public uint dwChannel;        //通道号
        public byte byCompressType;   //待获取的压缩参数类型1,主码流2,子码流3,事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留
        public NET_DVR_COMPRESSIONCFG_V30 struCurrentCfg; //当前压缩参数配置
    }
}
