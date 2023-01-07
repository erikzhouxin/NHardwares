using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHECK_FACE_PICTURE_COND
    {
        public uint dwSize;
        public uint dwPictureNum; //图片数量
        public byte byCheckTemplate; //0-校验图片是否合法（默认），1-校验图片和建模数据是否匹配
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
