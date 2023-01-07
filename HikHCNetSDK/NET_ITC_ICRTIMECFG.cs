using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICRTIMECFG
    {
        public NET_DVR_SCHEDTIME struTime;
        public byte byAssociateRresetNo;//预置点号1～8 , 0代表无
        public byte bySubSwitchMode;//1~白天，2~晚上 (当预置点等于0 的时候生效)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
