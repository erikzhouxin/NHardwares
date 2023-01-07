using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能设备能力集
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_DEV_ABILITY
    {
        public uint dwSize;//结构长度
        public byte byVCAChanNum;//智能通道个数
        public byte byPlateChanNum;//车牌通道个数
        public byte byBBaseChanNum;//行为基本版个数
        public byte byBAdvanceChanNum;//行为高级版个数
        public byte byBFullChanNum;//行为完整版个数
        public byte byATMChanNum;//智能ATM个数
        public byte byPDCChanNum;         //人数统计通道个数
        public byte byITSChanNum;         //交通事件通道个数
        public byte byBPrisonChanNum;     //行为监狱版(监舍)通道个数
        public byte byFSnapChanNum;       //人脸抓拍通道个数
        public byte byFSnapRecogChanNum;  //人脸抓拍和识别通道个数
        public byte byFRetrievalChanNum;  //人脸后检索个数
        public byte bySupport;            //能力，位与结果为0表示不支持，1表示支持
                                          //bySupport & 0x1，表示是否支持智能跟踪 2012-3-22
                                          //bySupport & 0x2，表示是否支持128路取流扩展2012-12-27
        public byte byFRecogChanNum;      //人脸识别通道个数
        public byte byBPPerimeterChanNum; //行为监狱版(周界)通道个数
        public byte byTPSChanNum;         //交通诱导通道个数
        public byte byTFSChanNum;         //道路违章取证通道个数
        public byte byFSnapBFullChanNum;  //人脸抓拍和行为分析通道个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 22, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
