using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_SDK_MANUALTHERM_BASICPARAM
    {
        public uint dwSize;
        public ushort wDistance;//距离(m)[0, 10000]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1; //保留
        public float fEmissivity;//发射率(发射率 精确到小数点后两位)[0.01, 1.00](即：物体向外辐射能量的本领)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
