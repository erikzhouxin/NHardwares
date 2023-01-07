using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEL_LABEL_PARAM
    {
        public uint dwSize;       // 结构体大小
        public byte byMode;   // 按位表示,0x01表示按标识删除
        public byte byRes1;
        public ushort wLabelNum;      // 标签数目   
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DEL_LABEL_IDENTIFY, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_LABEL_IDENTIFY[] struIndentify; // 标签标识
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 160, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   //保留字节    
    }
}
