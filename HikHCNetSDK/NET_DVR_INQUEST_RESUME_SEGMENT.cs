using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_RESUME_SEGMENT
    {
        public NET_DVR_TIME struStartTime; //事件起始时间
        public NET_DVR_TIME struStopTime;  //事件终止时间
        public byte byRoomIndex;         //审讯室编号,从1开始
        public byte byDriveIndex;        //刻录机编号,从1开始
        public ushort wSegmetSize;         //本片断的大小, 单位M 
        public uint dwSegmentNo;         //本片断在本次审讯中的序号,从1开始 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           //保留
    }
}
