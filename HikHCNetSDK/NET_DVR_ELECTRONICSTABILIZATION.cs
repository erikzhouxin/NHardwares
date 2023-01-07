using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //电子防抖
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ELECTRONICSTABILIZATION
    {
        public byte byEnable;//使能 0- 不启用，1- 启用
        public byte byLevel; //等级，0-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
