using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_SCREEN_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 172, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        /*[FieldOffsetAttribute(0)]
        public NET_DVR_DIGITALSCREEN struDigitalScreen;
        [FieldOffsetAttribute(0)]
        public NET_DVR_ANALOGSCREEN struAnalogScreen;
         * */
    }
}
