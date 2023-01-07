using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //字符串参数配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_OVERLAP_ITEM_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_OVERLAP_ITEM_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_ITS_OVERLAP_SINGLE_ITEM_PARAM[] struSingleItem;//字符串内容信息
        public uint dwLinePercent;
        public uint dwItemsStlye;
        public ushort wStartPosTop;
        public ushort wStartPosLeft;
        public ushort wCharStyle;
        public ushort wCharSize;
        public ushort wCharInterval;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public uint dwForeClorRGB;//前景色的RGB值，bit0~bit7: B，bit8~bit15: G，bit16~bit23: R，默认：x00FFFFFF-白
        public uint dwBackClorRGB;//背景色的RGB值，只对图片外叠加有效，bit0~bit7: B，bit8~bit15: G，bit16~bit23: R，默认：x00000000-黑 
        public byte byColorAdapt;//颜色是否自适应：0-否，1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
