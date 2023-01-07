using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_SENSOR_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.INQUEST_MAX_ROOM_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_INQUEST_SENSOR_DEVICE[] struSensorDevice;
        public uint dwSupportPro;      //支持协议类型,按位表示, 新版本走能力集，不再扩展此字段
                                       //0x1:米乐 0x2:镭彩 0x4:优力
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留
    }
}
