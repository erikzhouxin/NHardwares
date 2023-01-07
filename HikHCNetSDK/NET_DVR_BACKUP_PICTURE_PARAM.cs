using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BACKUP_PICTURE_PARAM
    {
        public uint dwSize;         // 结构体大小   
        public uint dwPicNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RECORD_PICTURE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_FIND_PICTURE[] struPicture;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDiskDes;
        public byte byWithPlayer;
        public byte byContinue;    /*是否继续备份 0不继续 1继续*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
