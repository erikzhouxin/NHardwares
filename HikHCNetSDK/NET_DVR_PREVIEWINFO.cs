using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //预览V40接口
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PREVIEWINFO
    {
        public Int32 lChannel;//通道号
        public uint dwStreamType;   // 码流类型，0-主码流，1-子码流，2-码流3，3-码流4 等以此类推
        public uint dwLinkMode;// 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式，4-RTP/RTSP,5-RSTP/HTTP 
        public IntPtr hPlayWnd;//播放窗口的句柄,为NULL表示不播放图象
        public bool bBlocked;  //0-非阻塞取流, 1-阻塞取流, 如果阻塞SDK内部connect失败将会有5s的超时才能够返回,不适合于轮询取流操作.
        public bool bPassbackRecord; //0-不启用录像回传,1启用录像回传
        public byte byPreviewMode;//预览模式，0-正常预览，1-延迟预览
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byStreamID;//流ID，lChannel为0xffffffff时启用此参数
        public byte byProtoType; //应用层取流协议，0-私有协议，1-RTSP协议
        public byte byRes1;
        public byte byVideoCodingType; //码流数据编解码类型 0-通用编码数据 1-热成像探测器产生的原始数据（温度数据的加密信息，通过去加密运算，将原始数据算出真实的温度值）
        public uint dwDisplayBufNum; //播放库播放缓冲区最大缓冲帧数，范围1-50，置0时默认为1 
        public byte byNPQMode;  //NPQ是直连模式，还是过流媒体 0-直连 1-过流媒体
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 215, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
