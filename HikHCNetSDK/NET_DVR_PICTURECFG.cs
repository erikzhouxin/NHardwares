using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PICTURECFG
    {
        public uint dwSize;        //大小
        public byte byUseType;    //1-底图，2-GIF图片，3-CAD图片 4-输出口图片
        public byte bySequence;//序号  
        public byte byOverlayEnabled; //图片叠加使能，是否在上传图片包含图片叠加参数 1-包含叠加参数，0-不包含
        public byte byRes;
        public NET_DVR_BASEMAP_CFG struBasemapCfg;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPicName;//图片名称
        public uint dwVideoWall;       //墙号（1字节墙号+1字节通道输出+2字节窗口号）
        public byte byFlash; //图片闪烁使能，1-闪烁，0-不闪烁
        public byte byTranslucent; //图片半透明使能，1-半透明，0-不半透明
        public byte byShowEnabled; //图片显示使能，1-显示，0-隐藏
        public byte byPictureType; //图片类型，1-bmp，2-jpg，3-png，……
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
