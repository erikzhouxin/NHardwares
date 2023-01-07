using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MULTI_STREAM_COMPRESSIONCFG
    {
        public uint dwSize;
        public uint dwStreamType;        //码流类型，0-主码流，1-子码流，2-事件类型，3-码流3，……
        public NET_DVR_COMPRESSION_INFO_V30 struStreamPara;        //码流压缩参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 80, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
