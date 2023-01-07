using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_POST_SINGLEIO_PARAM
    {
        public NET_ITC_PLATE_RECOG_PARAM struPlateRecog;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IOIN_NUMEX, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_SINGLEIO_PARAM[] struSingleIO;
    }

}
