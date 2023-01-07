using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //红绿灯功能（2个IO输入一组）
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LIGHTSNAPCFG
    {
        public uint dwSize;
        public byte byLightIoIn;//红绿灯的IO 号
        public byte byTrigIoIn;//触发的IO号
        public byte byRelatedDriveWay;//触发IO关联的车道号
        public byte byTrafficLight; //0-高电平红灯，低电平绿灯；1-高电平绿灯，低电平红灯
        public byte bySnapTimes1; //红灯抓拍次数1，0-不抓拍，非0-连拍次数，最大5次 
        public byte bySnapTimes2; //绿灯抓拍次数2，0-不抓拍，非0-连拍次数，最大5次 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTERVAL_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wIntervalTime1;//红灯连拍间隔时间，ms
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTERVAL_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wIntervalTime2;//绿灯连拍间隔时间，ms
        public byte byRecord;//闯红灯周期录像标志，0-不录像，1-录像
        public byte bySessionTimeout;//闯红灯周期录像超时时间（秒）
        public byte byPreRecordTime;//闯红灯录像片段预录时间(秒)
        public byte byVideoDelay;//闯红灯录像片段延时时间（秒）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留字节
    }



}
