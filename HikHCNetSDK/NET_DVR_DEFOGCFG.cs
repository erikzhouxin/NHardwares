using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //透雾
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEFOGCFG
    {
        public byte byMode; //模式，0-不启用，1-自动模式，2-常开模式
        public byte byLevel; //等级，0-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
