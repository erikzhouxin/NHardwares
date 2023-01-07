using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_SENSOR_DEVICE
    {
        public ushort wDeviceType;  //数据采集设备型号:0-无 1-米乐 2-镭彩 3-优力 4-佳盟 5-永控、6-垅上、7-维纳斯达
        public ushort wDeviceAddr;  //数据采集设备地址	
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 28, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留
    }
}
