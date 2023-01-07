using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Gamma校正
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GAMMACORRECT
    {
        public byte byGammaCorrectionEnabled; /*0 dsibale  1 enable*/
        public byte byGammaCorrectionLevel; /*0-100*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
