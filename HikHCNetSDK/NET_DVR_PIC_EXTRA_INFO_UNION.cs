using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_PIC_EXTRA_INFO_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 544, ArraySubType = UnmanagedType.I1)]
        public byte[] byUnionLen;   //联合体长度，无实际意义
    }
}
