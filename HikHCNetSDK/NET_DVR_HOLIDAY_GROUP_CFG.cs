using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDAY_GROUP_CFG
    {
        public uint dwSize;
        public byte byEnable; //whether to enable, 1-enable, 0-disable 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.HOLIDAY_GROUP_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byGroupName; //holiday group name 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HOLIDAY_PLAN_NUM, ArraySubType = UnmanagedType.U4)]
        public uint[] dwHolidayPlanNo; //holiday plan No. fill in from the front side, invalid when meet zero.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        public void Init()
        {
            byGroupName = new byte[HikHCNetSdk.HOLIDAY_GROUP_NAME_LEN];
            dwHolidayPlanNo = new uint[HikHCNetSdk.MAX_HOLIDAY_PLAN_NUM];
            byRes1 = new byte[3];
            byRes2 = new byte[32];
        }
    }


}
