using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_INPUTSTATUS_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 52, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        /*[FieldOffsetAttribute(0)]
        public NET_DVR_MATRIX_CHAN_STATUS struIpInputStatus;
        [FieldOffsetAttribute(0)]
        public NET_DVR_ANALOGINPUTSTATUS struAnalogInputStatus;
         * */
    }
}
