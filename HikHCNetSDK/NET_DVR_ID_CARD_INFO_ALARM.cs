using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //身份证信息报警
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ID_CARD_INFO_ALARM
    {
        public uint dwSize;        //结构长度
        public NET_DVR_ID_CARD_INFO struIDCardCfg;//身份证信息
        public uint dwMajor; //报警主类型，参考宏定义
        public uint dwMinor; //报警次类型，参考宏定义
        public NET_DVR_TIME_V30 struSwipeTime; //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byNetUser;//网络操作的用户名
        public NET_DVR_IPADDR struRemoteHostAddr;//远程主机地址
        public uint dwCardReaderNo; //读卡器编号，为0无效
        public uint dwDoorNo; //门编号，为0无效
        public uint dwPicDataLen;   //图片数据大小，不为0是表示后面带数据
        public IntPtr pPicData;
        public byte byCardType; //卡类型，1-普通卡，3-禁止名单卡，4-巡更卡，5-胁迫卡，6-超级卡，7-来宾卡，8-解除卡，为0无效
        public byte byDeviceNo;                             // 设备编号，为0时无效（有效范围1-255）
        public byte byMask; //是否带口罩：0-保留，1-未知，2-不戴口罩，3-戴口罩
        public byte byCurrentEvent;//是否为实时事件：0-无效，1-是（实时事件），2-否（离线事件）
        public uint dwFingerPrintDataLen;                  // 指纹数据大小，不为0是表示后面带数据
        public IntPtr pFingerPrintData;
        public uint dwCapturePicDataLen;                   // 抓拍图片数据大小，不为0是表示后面带数据
        public IntPtr pCapturePicData;
        public uint dwCertificatePicDataLen;   //证件抓拍图片数据大小，不为0是表示后面带数据
        public IntPtr pCertificatePicData;
        public byte byCardReaderKind; //读卡器属于哪一类，0-无效，1-IC读卡器，2-身份证读卡器，3-二维码读卡器,4-指纹头
        public byte byHelmet;//可选，是否戴安全帽：0-保留，1-未知，2-不戴安全, 3-戴安全帽
        public byte byRes3;
        public byte byIDCardInfoExtend;    //pIDCardInfoExtend是否有效：0-无效，1-有效
        public IntPtr pIDCardInfoExtend;    //byIDCardInfoExtend为1时，表示指向一个NET_DVR_ID_CARD_INFO_EXTEND结构体
        public uint dwSerialNo; //事件流水号，为0无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 168, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
