using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备通道信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEV_CHAN_INFO
    {
        public NET_DVR_IPADDR struIP;           //DVR IP地址
        public ushort wDVRPort;             //端口号
        public byte byChannel;              //通道号
        public byte byTransProtocol;        //传输协议类型0-TCP，1-UDP
        public byte byTransMode;            //传输码流模式 0－主码流 1－子码流
        public byte byFactoryType;          /*前端设备厂家类型,通过接口获取*/
        public byte byDeviceType; //设备类型(视频综合平台智能板使用)，1-解码器（此时根据视频综合平台能力集中byVcaSupportChanMode字段来决定是使用解码通道还是显示通道），2-编码器
        public byte byDispChan;//显示通道号,智能配置使用
        public byte bySubDispChan;//显示通道子通道号，智能配置时使用
        public byte byResolution;   //; 1-CIF 2-4CIF 3-720P 4-1080P 5-500w大屏控制器使用，大屏控制器会根据该参数分配解码资源
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byDomain; //设备域名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;    //监控主机登陆帐号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;    //监控主机密码
    }

}
