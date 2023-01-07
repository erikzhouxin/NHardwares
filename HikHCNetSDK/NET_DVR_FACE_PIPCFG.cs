using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_PIPCFG
    {
        public byte byEnable; //是否开启画中画
        public byte byBackChannel; //背景通道号（面板通道）
        public byte byPosition; //叠加位置，0-左上,1-左下,2-右上,3-右下
        public byte byPIPDiv; //分屏系数(人脸画面:面板画面)，0-1:4,1-1:9,2-1:16
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
