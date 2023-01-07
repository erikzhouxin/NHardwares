using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备支持AI开放平台接入，上传视频检测数据
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_AIOP_VIDEO_HEAD
    {
        public uint dwSize;      //dwSize = sizeof(NET_AIOP_VIDEO_HEAD)
        public uint dwChannel;    //设备分析通道的通道号；
        public NET_DVR_SYSTEM_TIME struTime;    //时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] szTaskID;     //视频任务ID，来自于视频任务派发
        public uint dwAIOPDataSize;   //对应AIOPDdata数据长度
        public uint dwPictureSize;    //对应分析图片长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] szMPID;        //检测模型包ID，用于匹配AIOP的检测数据解析；可以通过URI(GET /ISAPI/Intelligent/AIOpenPlatform/algorithmModel/management?format=json)获取当前设备加载的模型包的label description信息；
        public IntPtr pBufferAIOPData;  //AIOPDdata数据
        public IntPtr pBufferPicture;//对应分析图片数据
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 184, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
