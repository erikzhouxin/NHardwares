using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LLPOS_PARAM
    {
        public byte byLatitudeType;//纬度类型，0-北纬，1-南纬
        public byte byLongitudeType;//经度类型，0-东经，1-西经
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_LLI_PARAM struLatitude;    /*纬度*/
        public NET_DVR_LLI_PARAM struLongitude; /*经度*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
