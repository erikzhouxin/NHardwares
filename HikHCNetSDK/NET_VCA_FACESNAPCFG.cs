using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸抓拍规则参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACESNAPCFG
    {
        public uint dwSize;
        public byte bySnapTime;                 //单个目标人脸的抓拍次数0-10
        public byte bySnapInterval;                 //抓拍间隔，单位：帧
        public byte bySnapThreshold;               //抓拍阈值，0-100
        public byte byGenerateRate;         //目标生成速度,范围[1, 5]	
        public byte bySensitive;            //目标检测灵敏度，范围[1, 5]
        public byte byReferenceBright; //2012-3-27参考亮度[0,100]
        public byte byMatchType;         //2012-5-3比对报警模式，0-目标消失后报警，1-实时报警
        public byte byMatchThreshold;  //2012-5-3实时比对阈值，0~100
        public NET_DVR_JPEGPARA struPictureParam; //图片规格结构
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_SINGLE_FACESNAPCFG[] struRule; //人脸抓拍规则
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
