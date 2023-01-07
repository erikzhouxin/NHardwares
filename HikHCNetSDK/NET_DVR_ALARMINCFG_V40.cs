using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输入参数配置(256路NVR扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMINCFG_V40
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sAlarmInName; /* 名称 */
        public byte byAlarmType;                //报警器类型,0：常开,1：常闭
        public byte byAlarmInHandle;            /* 是否处理 0-不处理 1-处理*/
        public byte byChannel;                 // 报警输入触发智能识别通道
        public byte byRes1;                    //保留			
        public uint dwHandleType;        //异常处理,异常处理方式的"或"结果   
        /*0x00: 无响应*/
        /*0x01: 监视器上警告*/
        /*0x02: 声音警告*/
        /*0x04: 上传中心*/
        /*0x08: 触发报警输出*/
        /*0x10: 触发JPRG抓图并上传Email*/
        /*0x20: 无线声光报警器联动*/
        /*0x40: 联动电子地图(目前只有PCNVR支持)*/
        /*0x200: 抓图并上传FTP*/
        public uint dwMaxRelAlarmOutChanNum; //触发的报警输出通道数（只读）最大支持数量
        public uint dwRelAlarmOutChanNum; //触发的报警输出通道数 实际支持数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRelAlarmOut; //触发报警通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        /*触发的录像通道*/
        public uint dwMaxRecordChanNum;   //设备支持的最大关联录像通道数-只读
        public uint dwCurRecordChanNum;    //当前实际已配置的关联录像通道数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRelRecordChan;   /* 实际触发录像通道，按值表示,采用紧凑型排列，从下标0 - dwCurRecordChanNum -1有效，如果中间遇到0xffffffff,则后续无效*/
        public uint dwMaxEnablePtzCtrlNun; //最大可启用的云台控制总数(只读)
        public uint dwEnablePresetChanNum;  //当前已启用预置点的数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PRESETCHAN_INFO[] struPresetChanInfo; //启用的预置点信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 516, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                   /*保留*/
        public uint dwEnableCruiseChanNum;  //当前已启用巡航的通道数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CRUISECHAN_INFO[] struCruiseChanInfo; //启用巡航功能通道的信息
        public uint dwEnablePtzTrackChanNum;  //当前已启用巡航的通道数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PTZTRACKCHAN_INFO[] struPtzTrackInfo; //调用云台轨迹的通道信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
