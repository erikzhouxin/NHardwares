using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MULTI_STREAM_COMPRESSIONCFG_COND
    {
        public uint dwSize;
        public NET_DVR_STREAM_INFO struStreamInfo;
        public uint dwStreamType; //码流类型，0-主码流，1-子码流，2-事件类型，3-码流3，……（自定义码流类型需通过GET /ISAPI/Streaming/channels/<ID>/customStream获取当前通道已经添加的所有自定义码流ID。自定义码流为6~10，其索引值就是6~10）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
