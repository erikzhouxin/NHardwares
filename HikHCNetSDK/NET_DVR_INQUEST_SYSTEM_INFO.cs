using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_SYSTEM_INFO
    {
        public uint dwRecordMode;         //刻录模式:1 单室双刻模式 2 单室轮刻模式 3 双室双刻模式（修改需要重启设备）
        public uint dwWorkMode;           //工作模式:0 标准模式 1 通用模式(保留，目前只有标准模式)
        public uint dwResolutionMode;     //设备分辨率，0:标清 1:D1 2:720P 3:1080P（高清审讯机不用此字段）
        public NET_DVR_INQUEST_SENSOR_INFO struSensorInfo;  //温湿度传感器配置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.INQUEST_MAX_ROOM_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_INQUEST_ROOM_INFO[] struInquestRoomInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
