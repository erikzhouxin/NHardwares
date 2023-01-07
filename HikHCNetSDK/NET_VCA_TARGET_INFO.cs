using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //简化目标结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TARGET_INFO
    {
        public uint dwID;//目标ID ,人员密度过高报警时为0
        public NET_VCA_RECT struRect; //目标边界框 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
