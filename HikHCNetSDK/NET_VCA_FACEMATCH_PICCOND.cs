using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACEMATCH_PICCOND
    {
        public uint dwSize;             // 结构大小
        public uint dwSnapFaceID; //抓拍人脸子图ID
        public uint dwBlockListID; //匹配的禁止名单ID
        public uint dwBlockListFaceID; //比对的禁止名单人脸子图ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              // 保留字节
    }
}
