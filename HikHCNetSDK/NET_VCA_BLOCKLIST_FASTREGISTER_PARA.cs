using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_FASTREGISTER_PARA
    {
        public uint dwSize;   //结构大小
        public NET_VCA_BLOCKLIST_INFO struBlockListInfo;  //禁止名单基本参数
        public uint dwImageLen;  //图像数据长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
        public IntPtr pImage;    //图像数据
    }
}
