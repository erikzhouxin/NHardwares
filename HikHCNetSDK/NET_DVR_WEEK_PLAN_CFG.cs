using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WEEK_PLAN_CFG
    {
        public uint dwSize;
        public byte byEnable;  //whether to enable, 1-enable, 0-disable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_PLAN_SEGMENT[] struPlanCfg; //week plan parameter
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        public void Init()
        {
            struPlanCfg = new NET_DVR_SINGLE_PLAN_SEGMENT[HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30];
            foreach (NET_DVR_SINGLE_PLAN_SEGMENT singlStruPlanCfg in struPlanCfg)
            {
                singlStruPlanCfg.Init();
            }
            byRes1 = new byte[3];
            byRes2 = new byte[16];
        }
    }


}
