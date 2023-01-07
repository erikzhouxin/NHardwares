using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* 串口抓图设置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SERIAL_CATCHPIC_PARA
    {
        public byte byStrFlag;  /*串口数据开始符*/
        public byte byEndFlag;  /*结束符*/
        public ushort wCardIdx; /*卡号相对起始位*/
        public uint dwCardLen;  /*卡号长度*/
        public uint dwTriggerPicChans;  /*所触发的通道号，按位，从第1位开始计，即0x2表示第一通道*/
    }


}
