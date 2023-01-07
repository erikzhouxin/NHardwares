using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //备份过程接口定义
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BACKUP_NAME_PARAM
    {
        public uint dwFileNum;   //文件个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RECORD_FILE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_FINDDATA_V30[] struFileList; //文件列表
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDiskDes;   //备份磁盘描述
        public byte byWithPlayer;      //是否备份播放器
        public byte byContinue;    /*是否继续备份 0不继续 1继续*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;         //保留
    }
}
