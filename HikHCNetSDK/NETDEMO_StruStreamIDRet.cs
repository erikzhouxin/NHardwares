using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //流id录像查询结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struStreamIDRet
    {
        public uint dwRecordType;    //录像类型 0-定时录像 1-移动侦测 2-报警录像 3-报警|移动侦测 4-报警&移动侦测 5-命令触发 6-手动录像 7-震动报警 8-环境触发 9-智能报警 10-回传录像
        public uint dwRecordLength;    //录像大小
        public byte byLockFlag;    // 锁定标志 0：没锁定 1：锁定
        public byte byDrawFrameType;    // 0：非抽帧录像 1：抽帧录像
        public byte byPosition;// 文件所在存储位置：0-阵列上，1-带库机位上，可以直接下载，2-磁带库内，需要把磁盘切换到机位上，3-不在磁带库中，需要把磁盘插到磁带库中
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byFileName;     //文件名
        public uint dwFileIndex;            // 存档卷上的文件索引
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_MAX_TAPE_INDEX_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byTapeIndex;  //文件所在磁带编号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_MAX_FILE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byFileNameEx; //文件名扩展
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 464, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
