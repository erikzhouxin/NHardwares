using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICRCFG
    {
        public uint dwSize;
        public byte bySwitchType;//1~自动切换，2~手动切换 ,3~定时切换 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_ITC_ICR_PARAM_UNION uICRParam;
    }



}
