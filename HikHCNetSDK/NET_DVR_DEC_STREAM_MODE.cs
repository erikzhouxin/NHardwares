using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //取流模式配置联合体
    [StructLayout(LayoutKind.Explicit)]
    public struct NET_DVR_DEC_STREAM_MODE
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 300, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //联合体大小
        public void Init()
        {
            byRes = new byte[300];
        }
    }
}
