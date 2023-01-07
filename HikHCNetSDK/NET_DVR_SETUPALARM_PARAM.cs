using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警布防参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SETUPALARM_PARAM
    {
        public uint dwSize;
        public byte byLevel;//布防优先级：0- 一等级（高），1- 二等级（中），2- 三等级（低，保留）
        public byte byAlarmInfoType;//上传报警信息类型（智能交通摄像机支持）：0- 老报警信息（NET_DVR_PLATE_RESULT），1- 新报警信息(NET_ITS_PLATE_RESULT) 
        public byte byRetAlarmTypeV40;
        public byte byRetDevInfoVersion;
        public byte byRetVQDAlarmType;
        public byte byFaceAlarmDetection;
        public byte bySupport;
        public byte byBrokenNetHttp;
        public ushort wTaskNo;
        public byte byDeployType;    //布防类型：0-客户端布防，1-实时布防
        public byte bySubScription; //订阅，按位表示，未开启订阅不上报  //占位 //Bit7-移动侦测人车分类是否传图；0-不传图(V30上报)，1-传图(V40上报)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byAlarmTypeURL;
        //bit0-表示人脸抓拍报警上传（INTER_FACESNAP_RESULT）；0-表示二进制传输，1-表示URL传输（设备支持的情况下，设备支持能力根据具体报警能力集判断,同时设备需要支持URL的相关服务，当前是”云存储“）
        //bit1-表示EVENT_JSON中图片数据长传类型；0-表示二进制传输，1-表示URL传输（设备支持的情况下，设备支持能力根据具体报警能力集判断）
        //bit2 - 人脸比对(报警类型为COMM_SNAP_MATCH_ALARM)中图片数据上传类型：0 - 二进制传输，1 - URL传输
        //bit3 - 行为分析(报警类型为COMM_ALARM_RULE)中图片数据上传类型：0 - 二进制传输，1 - URL传输，本字段设备是否支持，对应软硬件能力集中<isSupportBehaviorUploadByCloudStorageURL>节点是否返回且为true
        public byte byCustomCtrl;//Bit0- 表示支持副驾驶人脸子图上传: 0-不上传,1-上传
    }
}
