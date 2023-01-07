using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_HOLIDATE_UNION
    {
        //联合体大小 12字节
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] dwSize;
        /*[FieldOffsetAttribute(0)]
        public NET_DVR_HOLIDATE_MODEA	struModeA;	// 模式A
        [FieldOffsetAttribute(0)]
        public NET_DVR_HOLIDATE_MODEB	struModeB;	// 模式B
        [FieldOffsetAttribute(0)]
        public NET_DVR_HOLIDATE_MODEC	struModeC;	// 模式C
         * */
    }
}
