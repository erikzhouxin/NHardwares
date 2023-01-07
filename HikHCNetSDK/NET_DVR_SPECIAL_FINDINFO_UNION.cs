using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_SPECIAL_FINDINFO_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byLenth;
        /* [FieldOffsetAttribute(0)]
         public NET_DVR_ATMFINDINFO struATMFindInfo;	       //ATM查询
         * */
    }
}
