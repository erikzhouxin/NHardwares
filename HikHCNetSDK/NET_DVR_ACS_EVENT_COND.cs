using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_COND
    {
        public uint dwSize;
        public uint dwMajor; //报警主类型，参考事件上传宏定义，0-全部
        public uint dwMinor; //报警次类型，参考事件上传宏定义，0-全部
        public NET_DVR_TIME struStartTime; //开始时间
        public NET_DVR_TIME struEndTime; //结束时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //卡号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName; //持卡人姓名
        public byte byPicEnable; //是否带图片，0-不带图片，1-带图片
        public byte byTimeType; //时间类型：0-设备本地时间（默认），1-UTC时间（struStartTime和struEndTime的时间）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
        public uint dwBeginSerialNo; //起始流水号（为0时默认全部）
        public uint dwEndSerialNo; //结束流水号（为0时默认全部）
        public uint dwIOTChannelNo; //IOT通道号，0-无效
        public ushort wInductiveEventType; //归纳事件类型，0-无效，其他值参见2.2章节，客户端判断该值为非0值后，报警类型通过归纳事件类型区分，否则通过原有报警主次类型（dwMajor、dwMinor）区分
        public byte bySearchType;      //搜索方式：0-保留，1-按事件源搜索（此时通道号为非视频通道号），2-按监控点ID搜索
        public byte byEventAttribute; //事件属性：0-未定义，1-合法事件，2-其它
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_MONITOR_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] szMonitorID;          //监控点ID（由设备序列号、通道类型、编号组成，例如门禁点：设备序列号+“DOOR”+门编号）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEmployeeNo; //工号（人员ID）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 140, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留

        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byName = new byte[HikHCNetSdk.NAME_LEN];
            byRes2 = new byte[2];
            byEmployeeNo = new byte[HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN];
            byRes = new byte[140];
        }
    }
}
