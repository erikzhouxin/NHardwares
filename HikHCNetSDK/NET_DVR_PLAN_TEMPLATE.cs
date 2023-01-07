using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAN_TEMPLATE
    {
        public uint dwSize;
        public byte byEnable; //whether to enable, 1-enable, 0-disable 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.TEMPLATE_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byTemplateName; //template name 
        public uint dwWeekPlanNo; //week plan no. 0 invalid
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HOLIDAY_GROUP_NUM, ArraySubType = UnmanagedType.U4)]
        public uint[] dwHolidayGroupNo; //holiday group. fill in from the front side, invalid when meet zero.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        public void Init()
        {
            byTemplateName = new byte[HikHCNetSdk.TEMPLATE_NAME_LEN];
            dwHolidayGroupNo = new uint[HikHCNetSdk.MAX_HOLIDAY_GROUP_NUM];
            byRes1 = new byte[3];
            byRes2 = new byte[32];
        }
    }


}
