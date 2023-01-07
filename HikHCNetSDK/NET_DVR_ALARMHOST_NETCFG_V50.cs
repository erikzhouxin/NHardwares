using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_NETCFG_V50
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CENTERNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ALARMHOST_NETPARAM_V50[] struNetCenter;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public void Init()
        {
            struNetCenter = new NET_DVR_ALARMHOST_NETPARAM_V50[HikHCNetSdk.MAX_CENTERNUM];
            byRes1 = new byte[128];
        }
    }

}
