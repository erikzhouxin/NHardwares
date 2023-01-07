using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOPLATFORM_ABILITY_V40
    {
        public uint dwSize;
        public byte byCodeSubSystemNums;
        public byte byDecodeSubSystemNums;//解码子系统数量
        public byte bySupportNat;//是否支持NAT，0-不支持，1-支持
        public byte byInputSubSystemNums;//级联输入子系统数量
        public byte byOutputSubSystemNums;//级联输出子系统数量
        public byte byCodeSpitterSubSystemNums;//码分子系统数量
        public byte byAlarmHostSubSystemNums;//报警子系统数量
        public byte bySupportBigScreenNum;//所支持最多组成大屏的个数
        public byte byVCASubSystemNums;//智能子系统数量
        public byte byV6SubSystemNums;//V6子系统数量
        public byte byV6DecoderSubSystemNums;//V6解码子系统数量
        public byte bySupportBigScreenX;/*大屏拼接的模式：m×n*/
        public byte bySupportBigScreenY;
        public byte bySupportSceneNums;//支持场景模式的个数
        public byte byVcaSupportChanMode;//智能支持的通道使用模式，0-使用解码通道，1-使用显示通道及子通道号
        public byte bySupportScreenNums;//所支持的大屏的屏幕最大个数
        public byte bySupportLayerNums;//所支持的图层数，0xff-无效
        public byte byNotSupportPreview;//是否支持预览,1-不支持，0-支持
        public byte byNotSupportStorage;//是否支持存储,1-不支持，0-支持
        public byte byUploadLogoMode;//上传logo模式，0-上传给解码通道，1-上传给显示通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SUBSYSTEM_NUM_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SUBSYSTEM_ABILITY[] struSubSystemAbility;
        public byte by485Nums;//485串口个数
        public byte by232Nums;//232串口个数
        public byte bySerieStartChan;//起始通道
        public byte byScreenMode;//大屏模式，0-主屏由客户端分配，1-主屏由设备端分配
        public byte byDevVersion;//设备版本，0-B10/B11/B12，1-B20
        public byte bySupportBaseMapNums;//所支持的底图数，底图号从1开始
        public ushort wBaseLengthX;//每个屏大小的基准值，B20使用
        public ushort wBaseLengthY;
        public byte bySupportPictureTrans;  //是否支持图片回显，0-不支持，1-支持	
        public byte bySupportPreAllocDec;   //是否支持智能解码资源预分配，0-不支持，1-支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 628, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
