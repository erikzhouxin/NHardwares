using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SPRCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHJC_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byDefaultCHN; /*设备运行省份的汉字简写*/
        public byte byPlateOSD;    /*0:不发送车牌彩色图,1:发送车牌彩色图*/
        public byte bySendJPEG1;   /*0-不传送近景JPEG图,1-传送近景JPEG图*/
        public byte bySendJPEG2;   /*0-不传送远景JPEG图,1-传送远景JPEG图*/
        public ushort wDesignedPlateWidth;   /*车牌设计宽度*/
        public byte byTotalLaneNum;  /*识别的车道数*/
        public byte byRes1;      /*保留*/
        public ushort wRecognizedLane;  /*识别的车道号，按位表示，bit0表示车道1是否识别，0-不识别，1-识别*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LANERECT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_RECT[] struLaneRect;  /*车道识别区域*/
        public uint dwRecogMode;  /*识别的类型，
	        bit0-背向识别：0-正向车牌识别，1-背向识别(尾牌识别) ； 
		    bit1-大车牌识别或小车牌识别：0-小车牌识别，1-大车牌识别 ；
		    bit2-车身颜色识别：0-不采用车身颜色识别，在背向识别或小车牌识别时禁止启用，1-车身颜色识别；
		    bit3-农用车识别：0-不采用农用车识别，1-农用车识别； 
		    bit4-模糊识别：0-不采用模糊识别，1-模糊识别；
		    bit5-帧定位或场定位：0-帧定位，1-场定位；
		    bit6-帧识别或场识别：0-帧识别，1-场识别； 
		    bit7-晚上或白天：0-白天，1-晚上 */
        public byte bySendPRRaw;        //是否发送原图：0-不发送，1-发送 
        public byte bySendBinImage;     //是否发送车牌二值图：0-不发送，1-发送 
        public byte byDelayCapture;  //延时抓拍控制,单位：帧
        public byte byUseLED;    //使用LED控制，0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;    //保留
    }

}
