using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************智能交通事件 end*****************************************/

    /******************************车牌识别 begin******************************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATE_PARAM
    {
        public byte byPlateRecoMode;    //车牌识别的模式,默认为1(视频触发模式)
        public byte byBelive;   /*整牌置信度阈值, 只用于视频识别方式, 根据背景复杂程度设置, 误触发率高就设高, 漏车率高就设低, 
                                     * 建议在80-90范围内*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 22, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;          //保留字节
    }



}
