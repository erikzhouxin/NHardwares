using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagACSTimeSection
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_TIME_SECTION_S
    {
        public Int64 tStartTime;
        public Int64 tEndTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;
    }

}
