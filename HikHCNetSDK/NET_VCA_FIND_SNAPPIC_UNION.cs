using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_VCA_FIND_SNAPPIC_UNION
    {
        //联合体大小为44字节
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        /*[FieldOffsetAttribute(0)]
        public NET_VCA_NORMAL_FIND  struNormalFind; //普通检索
        [FieldOffsetAttribute(0)]
        public NET_VCA_ADVANCE_FIND struAdvanceFind; //高级检索
         * */
    }
}
