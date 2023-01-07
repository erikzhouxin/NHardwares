using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LLI_PARAM
    {
        public float fSec;//秒[0.000000,60.000000]
        public byte byDegree;//度:纬度[0,90] 经度[0,180]
        public byte byMinute;//分[0,59]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
