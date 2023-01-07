using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备通道信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEV_CHAN_INFO_EX
    {
        public byte byChanType;             //通道类型：0-普通通道，1-零通道，2-流ID，3-本地输入源
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.STREAM_ID_LEN)]
        public string byStreamId;/* 流ID，通道类型 byChanType 为 2 时有效 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwChannel;//通道类型 byChanType为 0、1、3 时有效（如果通道类型为本地输入源，该参数值表示本地输入源索引）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string byAddress;/* 设备IP地址或者域名 */
        public ushort wDVRPort;             //端口号
        public byte byChannel;              //该参数无效，通道号见dwChannel 
        public byte byTransProtocol;        //传输协议类型0-TCP，1-UDP
        public byte byTransMode;            //传输码流模式 0－主码流 1－子码流
        public byte byFactoryType;          /*前端设备厂家类型,通过接口获取*/
        public byte byDeviceType; //设备类型(视频综合平台智能板使用)，1-解码器（此时根据视频综合平台能力集中byVcaSupportChanMode字段来决定是使用解码通道还是显示通道），2-编码器
        public byte byDispChan;//显示通道号,智能配置使用
        public byte bySubDispChan;//显示通道子通道号，智能配置时使用
        public byte byResolution;   //; 1-CIF 2-4CIF 3-720P 4-1080P 5-500w大屏控制器使用，大屏控制器会根据该参数分配解码资源
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string sUserName;            //监控主机登陆帐号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string sPassword;            //监控主机密码
    }
}
