using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR抓图参数配置（基线）
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_JPEGCFG_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_JPEGPARA[] struJpegPara; /*每个通道的图像参数*/
        public ushort wBurstMode;                           /*抓图方式,按位设置.0x1=报警输入触发，0x2=移动侦测触发 0x4=232触发，0x8=485触发，0x10=网络触发*/
        public ushort wUploadInterval;                  /*图片上传间隔(秒)[0,65535]*/
        public NET_DVR_PICTURE_NAME struPicNameRule;    /* 图片命名规则 */
        public byte bySaveToHD;     /*是否保存到硬盘*/
        public byte byRes1;
        public ushort wCatchInterval;       /*抓图间隔(毫秒)[0,65535]*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_SERIAL_CATCHPIC_PARA struRs232Cfg;
        public NET_DVR_SERIAL_CATCHPIC_PARA struRs485Cfg;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] dwTriggerPicTimes;    /* 每个通道一次触发拍照次数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] dwAlarmInPicChanTriggered; /*报警触发抓拍通道,按位设置，从第1位开始*/
    }


}
