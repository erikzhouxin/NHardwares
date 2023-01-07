using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TRAVERSE_PLANE_DETECTION
    {
        public uint dwSize;//结构体大小 
        public byte byEnable;//使能越界侦测功能：0- 否，1- 是  
        public byte byEnableDualVca; //启用支持智能后检索：0- 不启用，1- 启用 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALERTLINE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_TRAVERSE_PLANE[] struAlertParam;//警戒线参数

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmSched;//布防时间，每周7天，每天最多设置8个时间段 

        public NET_DVR_HANDLEEXCEPTION_V40 struHandleException;//异常处理方式 

        public uint dwMaxRelRecordChanNum;
        public uint dwRelRecordChanNum;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] byRelRecordChan;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struHolidayTime; //假日布防时间，最多设置8个时间段 

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
