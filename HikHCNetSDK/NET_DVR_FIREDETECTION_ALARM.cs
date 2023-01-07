using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //火点检测报警
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FIREDETECTION_ALARM
    {
        public uint dwSize; //结构大小
        public uint dwRelativeTime; //相对时标
        public uint dwAbsTime; //绝对时标
        public NET_VCA_DEV_INFO struDevInfo;   //前端设备信息
        public ushort wPanPos;
        public ushort wTiltPos;
        public ushort wZoomPos;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwPicDataLen;//报警抓拍图片长度
        public IntPtr pBuffer;    //数据指针
        public NET_VCA_RECT struRect;//火点框 
        public NET_VCA_POINT struPoint;//火点框内最高温度点坐标
        public ushort wFireMaxTemperature;//火点最高温度[300℃~4000℃]
        public ushort wTargetDistance;//目标距离[100m ~ 10000m]
        public byte byStrategyType;//策略类型；0~任意报警，1~协同报警，2~多系统报警，3~指定火点报警，4~指定烟雾报警
        public byte byAlarmSubType;//报警子类型。0~火点检测报警，1~烟雾检测报警，2~烟火报警
        /*是否启用PTZ坐标扩展，
        0~不启用，PTZ坐标值以wPanPos、wTiltPos、wZoomPos为准。
        1~启用，PTZ坐标值以struPtzPosEx为准。但是新老PTZ都需返回。struPtzPosEx的值需转化为wPanPos、wTiltPos、wZoomPos值。
        */
        public byte byPTZPosExEnable;
        public byte byRes2;
        public NET_PTZ_INFO struPtzPosEx;// ptz坐标扩展(支持高精度PTZ值，精确到小数点后三位)
        public uint dwVisiblePicLen;//可见光图片长度
        public IntPtr pVisiblePicBuf;    //可见光图片数据指针
                                         // pSmokeBuf参数当byAlarmSubType报警子类型为1（烟雾检测报警）、2（烟火报警）时生效。
        public IntPtr pSmokeBuf;    //烟雾检测报警数据指针，指向一个NET_DVR_SMOKEDETECTION_ALARM结构体
        public ushort wDevInfoIvmsChannelEx;     //与NET_VCA_DEV_INFO里的byIvmsChannel含义相同，能表示更大的值。老客户端用byIvmsChannel能继续兼容，但是最大到255。新客户端版本请使用wDevInfoIvmsChannelEx。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 58, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
