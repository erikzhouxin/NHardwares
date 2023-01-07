using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车牌识别配置参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PLATECFG
    {
        public uint dwSize;
        public byte byPicProType;//报警时图片处理方式 0-不处理 1-上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，设置为0
        public NET_DVR_JPEGPARA struPictureParam;//图片规格结构
        public NET_VCA_PLATEINFO struPlateInfo;//车牌信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;//处理方式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;//报警触发的录象通道,为1表示触发该通道
    }
}
