using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_ALRAM_INFO
    {
        public uint dwSize;           // PDC人流量报警上传结构体大小
        public byte byMode;            // 0 单帧统计结果 1最小时间段统计结果  
        public byte byChannel;           // 报警上传通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;         // 保留字节   
        public NET_VCA_DEV_INFO struDevInfo;                //前端设备信息
        public UNION_PDCPARAM uStatModeParam;
        public uint dwLeaveNum;        // 离开人数
        public uint dwEnterNum;        // 进入人数			
        public byte byBrokenNetHttp;     //断网续传标志位，0-不是重传数据，1-重传数据
        public byte byRes3;
        public ushort wDevInfoIvmsChannelEx;     //与NET_VCA_DEV_INFO里的byIvmsChannel含义相同，能表示更大的值。老客户端用byIvmsChannel能继续兼容，但是最大到255。新客户端版本请使用wDevInfoIvmsChannelEx
        public uint dwPassingNum;        // 经过人数（进入区域后徘徊没有触发进入、离开的人数）
        public uint dwChildLeaveNum;        // 小孩离开人数
        public uint dwChildEnterNum;        // 小孩进入人数
        public uint dwDuplicatePeople;        // 重复人数
        public uint dwXmlLen;//XML透传数据长度, 即EventNotificationAlert XML Block的数据长度
        public IntPtr pXmlBuf; // XML报警信息指针,其XML对应到EventNotificationAlert XML Block
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           // 保留字节
    }


}
