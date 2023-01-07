using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //测速功能(2个IO输入一组）
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MEASURESPEEDCFG
    {
        public uint dwSize;
        public byte byTrigIo1;   //测速第1线圈
        public byte byTrigIo2;   //测速第2线圈
        public byte byRelatedDriveWay;//触发IO关联的车道号
        public byte byTestSpeedTimeOut;//测速模式超时时间，单位s
        public uint dwDistance;//线圈距离,cm
        public byte byCapSpeed;//测速模式起拍速度，单位km/h
        public byte bySpeedLimit;//限速值，单位km/h
        public byte bySnapTimes1; //线圈1抓拍次数，0-不抓拍，非0-连拍次数，最大5次 
        public byte bySnapTimes2; //线圈2抓拍次数，0-不抓拍，非0-连拍次数，最大5次 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTERVAL_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wIntervalTime1;//线圈1连拍间隔时间，ms
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTERVAL_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wIntervalTime2;//线圈2连拍间隔时间，ms
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留字节
    }



}
