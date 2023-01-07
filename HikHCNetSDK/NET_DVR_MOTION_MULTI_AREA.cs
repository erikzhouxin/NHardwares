using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MOTION_MULTI_AREA
    {
        public byte byDayNightCtrl;//日夜控制 0~关闭,1~自动切换,2~定时切换(默认关闭)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_SCHEDULE_DAYTIME struScheduleTime;//切换时间  16
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_MULTI_AREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MOTION_MULTI_AREAPARAM[] struMotionMultiAreaParam;//最大支持24个区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
