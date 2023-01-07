using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //可视对讲事件记录
    public struct NET_DVR_VIDEO_INTERCOM_EVENT
    {
        public uint dwSize; //结构体大小
        public NET_DVR_TIME_EX struTime; //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DEV_NUMBER_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDevNumber; //设备编号
        public byte byEventType; //事件信息类型，1-开锁记录，2-公告信息阅读回执，3-认证记录，4-车牌信息上传，5非法卡刷卡事件，6-门口机发卡记录(需要启动门口机发卡功能，刷卡时才会上传该事件)
        public byte byPicTransType;        //图片数据传输方式: 0-二进制；1-url
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1; //保留
        public NET_DVR_VIDEO_INTERCOM_EVENT_INFO_UINON uEventInfo; //事件信息，具体内容参考byEventType取值
        public uint dwIOTChannelNo;    //IOT通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 252, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }
}
