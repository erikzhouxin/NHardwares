using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //取证方式
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FORENSICS_MODE
    {
        public uint dwSize;      //结构大小
        public byte byMode;      // 0-手动取证 ,1-自动取证
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   //保留
    }



}
