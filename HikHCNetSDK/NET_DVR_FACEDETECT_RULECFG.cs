using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸规则配置 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACEDETECT_RULECFG
    {
        public uint dwSize;              // 结构体大小
        public byte byEnable;            // 是否启用
        public byte byEventType;            //警戒事件类型， 0-异常人脸; 1-正常人脸;2-异常人脸&正常人脸;
        public byte byUpLastAlarm;       //2011-04-06 是否先上传最近一次的报警
        public byte byUpFacePic; //是否上传人脸子图，0-否，1-是	
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;
        public NET_VCA_POLYGON struVcaPolygon;    // 人脸检测规则区域
        public byte byPicProType;   //报警时图片处理方式 0-不处理 非0-上传
        public byte bySensitivity;   // 规则灵敏度
        public ushort wDuration;      // 触发人脸报警时间阈值
        public NET_DVR_JPEGPARA struPictureParam;       //图片规格结构
        public NET_VCA_SIZE_FILTER struSizeFilter;         //尺寸过滤器
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;    //处理方式 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;          //报警触发的录象通道,为1表示触发该通道
        public byte byPicRecordEnable;  /*2012-3-1是否启用图片存储, 0-不启用, 1-启用*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 39, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;         //保留字节
    }



}
