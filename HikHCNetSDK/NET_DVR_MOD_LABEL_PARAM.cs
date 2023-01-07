using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MOD_LABEL_PARAM
    {
        public NET_DVR_LABEL_IDENTIFY struIndentify; //要修改的标签标识
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LABEL_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLabelName;   //修改后的标签名称
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
