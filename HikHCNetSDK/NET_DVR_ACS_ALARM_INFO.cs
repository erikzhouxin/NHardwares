using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_ALARM_INFO
    {
        public uint dwSize;
        public uint dwMajor; //报警主类型，参考宏定义
        public uint dwMinor; //报警次类型，参考宏定义
        public NET_DVR_TIME struTime; //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNetUser;//网络操作的用户名
        public NET_DVR_IPADDR struRemoteHostAddr;//远程主机地址
        public NET_DVR_ACS_EVENT_INFO struAcsEventInfo; //详细参数
        public uint dwPicDataLen;   //图片数据大小，不为0是表示后面带数据
        public IntPtr pPicData;
        public ushort wInductiveEventType; //归纳事件类型，0-无效，客户端判断该值为非0值后，报警类型通过归纳事件类型区分，否则通过原有报警主次类型（dwMajor、dwMinor）区分
        public byte byPicTransType;        //图片数据传输方式: 0-二进制；1-url
        public byte byRes1;             //保留字节
        public uint dwIOTChannelNo;    //IOT通道号
        public IntPtr pAcsEventInfoExtend;    //byAcsEventInfoExtend为1时，表示指向一个NET_DVR_ACS_EVENT_INFO_EXTEND结构体
        public byte byAcsEventInfoExtend;    //pAcsEventInfoExtend是否有效：0-无效，1-有效
        public byte byTimeType; //时间类型：0-设备本地时间，1-UTC时间（struTime的时间）
        public byte byRes2;             //保留字节
        public byte byAcsEventInfoExtendV20;    //pAcsEventInfoExtendV20是否有效：0-无效，1-有效
        public IntPtr pAcsEventInfoExtendV20;    //byAcsEventInfoExtendV20为1时，表示指向一个NET_DVR_ACS_EVENT_INFO_EXTEND_V20结构体
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
