using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频质量诊断事件参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VQD_EVENT_PARAM
    {
        public byte byThreshold;    //报警阈值，范围[0,100]
        public byte byTriggerMode;  //1-持续触发，2-单次触发
        public byte byUploadPic;    //0-不上传图片，1-上传图片，无论是否上传图片，事后都可以从设备获取该事件所对应最新的一张报警图片，参见接口NET_DVR_StartDownload
        public byte byRes1;         //保留
        public uint dwTimeInterval; //持续触发报警时间间隔，范围[0,3600] 单位：秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;     //保留
    }
}
