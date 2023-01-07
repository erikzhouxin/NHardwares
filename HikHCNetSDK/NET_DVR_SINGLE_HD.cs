using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //本地硬盘信息配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_HD
    {
        public uint dwHDNo;/*硬盘号, 取值0~MAX_DISKNUM_V30-1*/
        public uint dwCapacity;/*硬盘容量(不可设置)*/
        public uint dwFreeSpace;/*硬盘剩余空间(不可设置)*/
        public uint dwHdStatus;/*硬盘状态(不可设置) HD_STAT*/
        public byte byHDAttr;/*0-默认, 1-冗余; 2-只读*/
        public byte byHDType;/*0-本地硬盘,1-ESATA硬盘,2-NAS硬盘*/
        public byte byDiskDriver;   // 值 代表其ASCII字符 
        public byte byRes1;
        public uint dwHdGroup; /*属于哪个盘组 1-MAX_HD_GROUP*/
        public byte byRecycling;   // 是否循环利用 0：不循环利用，1：循环利用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public uint dwStorageType;    //按位表示 0-不支持 非0-支持
                                      // dwStorageType & 0x1 表示是否是普通录像专用存储盘     
                                      // dwStorageType & 0x2  表示是否是抽帧录像专用存储盘
                                      // dwStorageType & 0x4 表示是否是图片录像专用存储盘

        public uint dwPictureCapacity; //硬盘图片容量(不可设置)，单位:MB
        public uint dwFreePictureSpace; //剩余图片空间(不可设置)，单位:MB
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 104, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }

}
