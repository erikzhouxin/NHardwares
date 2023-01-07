using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //从通道信息联合体
    [StructLayout(LayoutKind.Explicit)]
    public struct NET_DVR_SLAVE_CHANNEL_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 152, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //联合体大小
    }
}
