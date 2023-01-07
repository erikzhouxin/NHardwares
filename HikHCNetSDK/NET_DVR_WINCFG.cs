using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*窗口信息*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WINCFG
    {
        public uint dwSize;
        public byte byVaild;
        public byte byInputIdx;          /*输入源索引*/
        public byte byLayerIdx;          /*图层，0为最底层*/
        public byte byTransparency; //透明度，0～100 
        public NET_DVR_RECTCFG struWin;//目的窗口(相对显示墙)
        public ushort wScreenHeight;//大屏高
        public ushort wScreenWidth;//大屏宽
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
