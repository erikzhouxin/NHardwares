using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SNAPCFG
    {
        public uint dwSize;
        public byte byRelatedDriveWay;
        public byte bySnapTimes;
        public ushort wSnapWaitTime;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INTERVAL_NUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wIntervalTime;
        public uint dwSnapVehicleNum; //抓拍车辆序号。
        public NET_DVR_JPEGPARA struJpegPara;//抓拍图片参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }



}
