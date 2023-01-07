using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //宽动态配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WDR
    {
        public byte byWDREnabled; /*宽动态：0 dsibale  1 enable 2 auto*/
        public byte byWDRLevel1; /*0-F*/
        public byte byWDRLevel2; /*0-F*/
        public byte byWDRContrastLevel; /*0-100*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
