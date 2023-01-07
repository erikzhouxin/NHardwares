using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备支持AI开放平台接入，上传图片检测数据
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_AIOP_PICTURE_HEAD
    {
        public uint dwSize;           //dwSize = sizeof(NET_AIOP_PICTURE_HEAD)
        public NET_DVR_SYSTEM_TIME struTime;    //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] szPID;        //透传下发的图片ID，来自于图片任务派发
        public uint dwAIOPDataSize;   //对应AIOPDdata数据长度
        public byte byStatus;         //状态值：0-成功，1-图片大小错误
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] szMPID; //检测模型包ID，用于匹配AIOP的检测数据解析；
        public IntPtr pBufferAIOPData;//AIOPDdata数据
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 184, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
