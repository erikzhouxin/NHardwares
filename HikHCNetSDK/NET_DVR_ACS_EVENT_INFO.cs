using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_INFO
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //卡号，为0无效
        public byte byCardType; //卡类型，1-普通卡，3-禁止名单卡，4-巡更卡，5-胁迫卡，6-超级卡，7-来宾卡，为0无效
        public byte byAllowListNo; //允许名单单号,1-8，为0无效
        public byte byReportChannel; //报告上传通道，1-布防上传，2-中心组1上传，3-中心组2上传，为0无效
        public byte byCardReaderKind; //读卡器属于哪一类，0-无效，1-IC读卡器，2-身份证读卡器，3-二维码读卡器,4-指纹头
        public uint dwCardReaderNo; //读卡器编号，为0无效
        public uint dwDoorNo; //门编号(楼层编号)，为0无效
        public uint dwVerifyNo; //多重卡认证序号，为0无效
        public uint dwAlarmInNo;  //报警输入号，为0无效
        public uint dwAlarmOutNo; //报警输出号，为0无效
        public uint dwCaseSensorNo; //事件触发器编号
        public uint dwRs485No;    //RS485通道号，为0无效
        public uint dwMultiCardGroupNo; //群组编号
        public ushort wAccessChannel;    //人员通道号
        public byte byDeviceNo;    //设备编号，为0无效
        public byte byDistractControlNo;//分控器编号，为0无效
        public uint dwEmployeeNo; //工号，为0无效
        public ushort wLocalControllerID; //就地控制器编号，0-门禁主机，1-64代表就地控制器
        public byte byInternetAccess; //网口ID：（1-上行网口1,2-上行网口2,3-下行网口1）
        public byte byType;     //防区类型，0:即时防区,1-24小时防区,2-延时防区 ,3-内部防区，4-钥匙防区 5-火警防区 6-周界防区 7-24小时无声防区  8-24小时辅助防区，9-24小时震动防区,10-门禁紧急开门防区，11-门禁紧急关门防区 0xff-无
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr; //物理地址，为0无效
        public byte bySwipeCardType;//刷卡类型，0-无效，1-二维码
        public byte byMask;//是否带口罩：0-保留，1-未知，2-不戴口罩，3-戴口罩
        public uint dwSerialNo; //事件流水号，为0无效
        public byte byChannelControllerID; //通道控制器ID，为0无效，1-主通道控制器，2-从通道控制器
        public byte byChannelControllerLampID; //通道控制器灯板ID，为0无效（有效范围1-255）
        public byte byChannelControllerIRAdaptorID; //通道控制器红外转接板ID，为0无效（有效范围1-255）
        public byte byChannelControllerIREmitterID; //通道控制器红外对射ID，为0无效（有效范围1-255）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
