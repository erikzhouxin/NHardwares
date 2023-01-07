using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_SCREEN_CONTROL_PARAM
    {
        /*[FieldOffsetAttribute(0)]
        public NET_DVR_INPUT_INTERFACE_CTRL struInputCtrl;
        [FieldOffsetAttribute(0)]
        public NET_DVR_DISPLAY_COLOR_CTRL struDisplayCtrl;
        [FieldOffsetAttribute(0)]
        public NET_DVR_DISPLAY_POSITION_CTRL struPositionCtrl;
        [FieldOffsetAttribute(0)]
         * */
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
