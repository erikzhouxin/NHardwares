using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************获取设备状态*******************************/
    /*预案列表*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAN_LIST
    {
        public uint dwSize;
        public uint dwPlanNums;         //设备输入信号源数量
        public IntPtr pBuffer;          //指向dwInputSignalNums个NET_DVR_PLAN_CFG结构大小的缓冲区
        public byte byWallNo;           //墙号，从1开始
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwBufLen;           //所分配缓冲区长度，输入参数（大于等于dwInputSignalNums个NET_DVR_PLAN_CFG结构大小）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
