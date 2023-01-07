using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_DETAIL
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //卡号（mac地址），为0无效
        public byte byCardType; //卡类型，1-普通卡，3-禁止名单卡，4-巡更卡，5-胁迫卡，6-超级卡，7-来宾卡，8-解除卡，为0无效
        public byte byAllowListNo; //允许名单单号,1-8，为0无效
        public byte byReportChannel; //报告上传通道，1-布防上传，2-中心组1上传，3-中心组2上传，为0无效
        public byte byCardReaderKind; //读卡器属于哪一类，0-无效，1-IC读卡器，2-身份证读卡器，3-二维码读卡器,4-指纹头
        public uint dwCardReaderNo; //读卡器编号，为0无效
        public uint dwDoorNo; //门编号（楼层编号），为0无效
        public uint dwVerifyNo; //多重卡认证序号，为0无效
        public uint dwAlarmInNo;  //报警输入号，为0无效
        public uint dwAlarmOutNo; //报警输出号，为0无效
        public uint dwCaseSensorNo; //事件触发器编号
        public uint dwRs485No;    //RS485通道号，为0无效
        public uint dwMultiCardGroupNo; //群组编号
        public ushort wAccessChannel;    //人员通道号
        public byte byDeviceNo; //设备编号，为0无效（有效范围1-255）
        public byte byDistractControlNo;//分控器编号，为0无效
        public uint dwEmployeeNo; //工号，为0无效
        public ushort wLocalControllerID; //就地控制器编号，0-门禁主机，1-64代表就地控制器
        public byte byInternetAccess; //网口ID：（1-上行网口1,2-上行网口2,3-下行网口1）
        public byte byType;     //防区类型，0:即时防区,1-24小时防区,2-延时防区 ,3-内部防区，4-钥匙防区 5-火警防区 6-周界防区 7-24小时无声防区  8-24小时辅助防区，9-24小时震动防区,10-门禁紧急开门防区，11-门禁紧急关门防区 0xff-无
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr; //物理地址，为0无效
        public byte bySwipeCardType;//刷卡类型，0-无效，1-二维码
        public byte byEventAttribute; //事件属性：0-未定义，1-合法认证，2-其它
        public uint dwSerialNo; //事件流水号，为0无效
        public byte byChannelControllerID; //通道控制器ID，为0无效，1-主通道控制器，2-从通道控制器
        public byte byChannelControllerLampID; //通道控制器灯板ID，为0无效（有效范围1-255）
        public byte byChannelControllerIRAdaptorID; //通道控制器红外转接板ID，为0无效（有效范围1-255）
        public byte byChannelControllerIREmitterID; //通道控制器红外对射ID，为0无效（有效范围1-255）
        public uint dwRecordChannelNum; //录像通道数目
        public IntPtr pRecordChannelData;//录像通道，大小为sizeof(DWORD)* dwRecordChannelNum
        public byte byUserType; //人员类型：0-无效，1-普通人（主人），2-来宾（访客），3-禁止名单人，4-管理员
        public byte byCurrentVerifyMode; //读卡器当前验证方式：0-无效，1-休眠，2-刷卡+密码，3-刷卡，4-刷卡或密码，5-指纹，6-指纹+密码，7-指纹或刷卡，8-指纹+刷卡，9-指纹+刷卡+密码，10-人脸或指纹或刷卡或密码，11-人脸+指纹，12-人脸+密码，
                                         //13-人脸+刷卡，14-人脸，15-工号+密码，16-指纹或密码，17-工号+指纹，18-工号+指纹+密码，19-人脸+指纹+刷卡，20-人脸+密码+指纹，21-工号+人脸，22-人脸或人脸+刷卡，23-指纹或人脸，24-刷卡或人脸或密码，25-刷卡或人脸，26-刷卡或人脸或指纹，27-刷卡或指纹或密码
        public byte byAttendanceStatus;  //考勤状态：0-未定义,1-上班，2-下班，3-开始休息，4-结束休息，5-开始加班，6-结束加班
        public byte byStatusValue;  //考勤状态值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEmployeeNo; //工号（人员ID）（对于设备来说，如果使用了工号（人员ID）字段，byEmployeeNo一定要传递，如果byEmployeeNo可转换为dwEmployeeNo，那么该字段也要传递；对于上层平台或客户端来说，优先解析byEmployeeNo字段，如该字段为空，再考虑解析dwEmployeeNo字段）
        public byte byRes1; //保留
        public byte byMask; //是否带口罩：0-保留，1-未知，2-不戴口罩，3-戴口罩
        public byte byThermometryUnit; //测温单位（0-摄氏度（默认），1-华氏度，2-开尔文）
        public byte byIsAbnomalTemperature; //人脸抓拍测温是否温度异常：1-是，0-否
        public float fCurrTemperature; //人脸温度（精确到小数点后一位）
        public NET_VCA_POINT struRegionCoordinates; //人脸温度坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byMACAddr = new byte[HikHCNetSdk.MACADDR_LEN];
            byEmployeeNo = new byte[HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN];
            byRes = new byte[48];
        }
    }
}
