using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FIND_PICTURE_V50
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PICTURE_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sFileName;//图片名
        public NET_DVR_TIME struTime;//图片的时间
        public uint dwFileSize;//图片的大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CARDNUM_LEN_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] sCardNum;    //卡号
        public byte byPlateColor;//参考结构 VCA_PLATE_COLOR
        public byte byVehicleLogo;//参考结构 VLR_VEHICLE_CLASS
        public byte byFileType;  //文件类型， :0定时抓图1 移动侦测抓图 2 报警抓图3  报警 | 移动侦测抓图 4 报警 & 移动侦测抓图     6 手动抓图 ,9-智能图片,10- PIR报警，11- 无线报警，12- 呼救报警,    0xa 预览时截图，0xd 人脸侦测, 0xe 越界侦测，0xf 入侵区域侦测，0x10 场景变更侦测, 0x11-设备本地回放时截图, 0x12-智能侦测
        public byte byRecogResult;//识别结果参考结构VTR_RESULT
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LICENSE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLicense;    //车牌号码
        public byte byEventSearchStatus; //连续图片表示同一查找结果的时候，0-表示后面没有图片信息，1-表示后面还有图片信息。总共图片信息包括最后一张状态为0的图片。
        public NET_DVR_ADDRESS struAddr;        //图片所在的地址信息，图片下载时用到
        public byte byISO8601;  //是否是8601的时间格式，即时差字段是否有效0-时差无效，年月日时分秒为设备本地时间 1-时差有效 
        public byte cTimeDifferenceH;   //与UTC的时差（小时），-12 ... +14
        public byte cTimeDifferenceM;   //与UTC的时差（分钟），-30,0, 30, 45
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 253, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //  保留字节
        public NET_DVR_PIC_EXTRA_INFO_UNION uPicExtraInfo; //图片附件信息
    }
}
