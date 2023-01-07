using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATECFG
    {
        public uint dwSize;
        public uint dwEnable;                          /* 是否启用视频车牌识别 0－否 1－是 */
        public byte byPicProType;   //报警时图片处理方式 0-不处理 非0-上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  // 保留字节
        public NET_DVR_JPEGPARA struPictureParam;       //图片规格结构
        public NET_DVR_PLATE_PARAM struPlateParam;   // 车牌识别参数配置
        public NET_DVR_HANDLEEXCEPTION struHandleType;     /* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;        //报警触发的录象通道,为1表示触发该通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   // 保留字节
    }



}
