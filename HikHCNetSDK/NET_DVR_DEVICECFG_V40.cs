using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR设备参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEVICECFG_V40
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDVRName; //DVR名称
        public uint dwDVRID;                //DVR ID,用于遥控器 //V1.4(0-99), V1.5(0-255)
        public uint dwRecycleRecord;        //是否循环录像,0:不是; 1:是
                                            //以下不可更改
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber; //序列号
        public uint dwSoftwareVersion;          //软件版本号,高16位是主版本,低16位是次版本
        public uint dwSoftwareBuildDate;            //软件生成日期,0xYYYYMMDD
        public uint dwDSPSoftwareVersion;           //DSP软件版本,高16位是主版本,低16位是次版本
        public uint dwDSPSoftwareBuildDate;     // DSP软件生成日期,0xYYYYMMDD
        public uint dwPanelVersion;             // 前面板版本,高16位是主版本,低16位是次版本
        public uint dwHardwareVersion;  // 硬件版本,高16位是主版本,低16位是次版本
        public byte byAlarmInPortNum;       //DVR报警输入个数
        public byte byAlarmOutPortNum;      //DVR报警输出个数
        public byte byRS232Num;         //DVR 232串口个数
        public byte byRS485Num;         //DVR 485串口个数 
        public byte byNetworkPortNum;       //网络口个数
        public byte byDiskCtrlNum;          //DVR 硬盘控制器个数
        public byte byDiskNum;              //DVR 硬盘个数
        public byte byDVRType;              //DVR类型, 1:DVR 2:ATM DVR 3:DVS ......
        public byte byChanNum;              //DVR 通道个数
        public byte byStartChan;            //起始通道号,例如DVS-1,DVR - 1
        public byte byDecordChans;          //DVR 解码路数
        public byte byVGANum;               //VGA口的个数 
        public byte byUSBNum;               //USB口的个数
        public byte byAuxoutNum;            //辅口的个数
        public byte byAudioNum;         //语音口的个数
        public byte byIPChanNum;            //最大数字通道数 低8位，高8位见byHighIPChanNum 
        public byte byZeroChanNum;          //零通道编码个数
        public byte bySupport;        //能力，位与结果为0表示不支持，1表示支持，
                                      //bySupport & 0x1, 表示是否支持智能搜索
                                      //bySupport & 0x2, 表示是否支持备份
                                      //bySupport & 0x4, 表示是否支持压缩参数能力获取
                                      //bySupport & 0x8, 表示是否支持多网卡
                                      //bySupport & 0x10, 表示支持远程SADP
                                      //bySupport & 0x20, 表示支持Raid卡功能
                                      //bySupport & 0x40, 表示支持IPSAN搜索
                                      //bySupport & 0x80, 表示支持rtp over rtsp
        public byte byEsataUseage;      //Esata的默认用途，0-默认备份，1-默认录像
        public byte byIPCPlug;          //0-关闭即插即用，1-打开即插即用
        public byte byStorageMode;      //0-盘组模式,1-磁盘配额, 2抽帧模式
        public byte bySupport1;     //能力，位与结果为0表示不支持，1表示支持
                                    //bySupport1 & 0x1, 表示是否支持snmp v30
                                    //bySupport1 & 0x2, 支持区分回放和下载
                                    //bySupport1 & 0x4, 是否支持布防优先级	
                                    //bySupport1 & 0x8, 智能设备是否支持布防时间段扩展
                                    //bySupport1 & 0x10, 表示是否支持多磁盘数（超过33个）
                                    //bySupport1 & 0x20, 表示是否支持rtsp over http	
        public ushort wDevType;//设备型号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DEV_TYPE_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDevTypeName;//设备型号名称 
        public byte bySupport2; //能力集扩展，位与结果为0表示不支持，1表示支持
                                //bySupport2 & 0x1, 表示是否支持扩展的OSD字符叠加(终端和抓拍机扩展区分)
        public byte byAnalogAlarmInPortNum; //模拟报警输入个数
        public byte byStartAlarmInNo;    //模拟报警输入起始号
        public byte byStartAlarmOutNo;  //模拟报警输出起始号
        public byte byStartIPAlarmInNo;  //IP报警输入起始号  0-无效
        public byte byStartIPAlarmOutNo; //IP报警输出起始号 0-无效
        public byte byHighIPChanNum;     //数字通道个数，高8位 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           //保留
    }
}
