using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //零通道缩放参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ZERO_ZOOMCFG
    {
        public uint dwSize;             //结构长度
        public NET_VCA_POINT struPoint; //画面中的坐标点
        public byte byState;         //现在的状态，0-缩小，1-放大  
        public byte byPreviewNumber;       //预览数目,0-1画面,1-4画面,2-9画面,3-16画面 该参数只读
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOW_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byPreviewSeq;//画面通道信息 该参数只读
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                //保留 
    }
}
