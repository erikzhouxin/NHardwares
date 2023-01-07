using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_PLATE_RECOG_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string byDefaultCHN;
        public byte byEnable;
        public uint dwRecogMode;
        public byte byVehicleLogoRecog;
        public byte byProvince;
        public byte byRegion;
        public byte byRes1;
        public ushort wPlatePixelWidthMin;
        public ushort wPlatePixelWidthMax;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
