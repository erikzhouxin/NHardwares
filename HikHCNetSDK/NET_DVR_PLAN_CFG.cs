using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*预案管理*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAN_CFG
    {
        public uint dwSize;
        public byte byValid;        // 该预案是否有效
        public byte byWorkMode;     // 预案工作模式 1表示手动，2自动，3预案循环
        public byte byWallNo;       //电视墙号，从1开始
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPlanName; //预案名称
        public NET_DVR_TIME_EX struTime; // 工作模式为自动时使用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DAYS_A_WEEK, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CYCLE_TIME[] struTimeCycle; /*循环时间，周期为一个星期，年、月、日三个参数不使用。如：struTimeCycle[0]中的byValid的值是1，表示星期天执行该预案。星期取值区间为[0,6]，其中0代表星期天，1代表星期一，以此类推*/
        public uint dwWorkCount;    // 预案内容执行次数，0为一直循环播放，其他值表示次数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_PLAN_ACTION_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PLAN_INFO[] strPlanEntry;  // 预案执行的内容
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
