using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACEDETECT_ALARM
    {
        public uint dwSize;             // 结构大小
        public uint dwRelativeTime; // 相对时标
        public uint dwAbsTime;          // 绝对时标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRuleName;   // 规则名称
        public NET_VCA_TARGET_INFO struTargetInfo;  //报警目标信息
        public NET_VCA_DEV_INFO struDevInfo;        //前端设备信息
        public uint dwPicDataLen;                       //返回图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据*/
        public byte byAlarmPicType;         // 0-异常人脸报警图片 1- 人脸图片,2-多张人脸 
        public byte byPanelChan;        /*2012-3-1人脸通道关联的面板通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwFacePicDataLen;           //人脸图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              // 保留字节
        public IntPtr pFaceImage; //指向人脸图指针
        public IntPtr pImage;                           //指向图片的指针
    }



}
