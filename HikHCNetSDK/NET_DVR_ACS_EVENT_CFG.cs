using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ACS_EVENT_CFG
    {
        public uint dwSize;
        public uint dwMajor; //报警主类型，参考宏定义
        public uint dwMinor; //报警次类型，参考宏定义
        public NET_DVR_TIME struTime; //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNetUser;//网络操作的用户名
        public NET_DVR_IPADDR struRemoteHostAddr;//远程主机地址
        public NET_DVR_ACS_EVENT_DETAIL struAcsEventInfo; //详细参数
        public uint dwPicDataLen;   //图片数据大小，不为0是表示后面带数据
        public IntPtr pPicData;
        public ushort wInductiveEventType; //归纳事件类型，0-无效，其他值参见2.2章节，客户端判断该值为非0值后，报警类型通过归纳事件类型区分，否则通过原有报警主次类型（dwMajor、dwMinor）区分
        public byte byTimeType; //时间类型：0-设备本地时间（默认），1-UTC时间（struTime的时间）
        public byte byRes1;
        public uint dwQRCodeInfoLen; //二维码信息长度，不为0是表示后面带数据
        public uint dwVisibleLightDataLen; //热成像相机可见光图片长度，不为0是表示后面带数据
        public uint dwThermalDataLen; //热成像图片长度，不为0是表示后面带数据
        public IntPtr pQRCodeInfo; //二维码信息指针
        public IntPtr pVisibleLightData; //热成像相机可见光图片指针
        public IntPtr pThermalData; //热成像图片指针
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            sNetUser = new byte[HikHCNetSdk.MAX_NAMELEN];
            struRemoteHostAddr.Init();
            struAcsEventInfo.Init();
            byRes = new byte[36];
        }
    }
}
