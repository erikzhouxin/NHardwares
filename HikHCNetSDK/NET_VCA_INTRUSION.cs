using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //根据报警延迟时间来标识报警中带图片，报警间隔和IO报警一致，1秒发送一个。
    //入侵参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_INTRUSION
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;//报警延迟时间: 1-120秒，建议5秒，判断是有效报警的时间
        public byte bySensitivity;        //灵敏度参数，范围[1-100]
        public byte byRate;               //占比：区域内所有未报警目标尺寸目标占区域面积的比重，归一化为－；
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
