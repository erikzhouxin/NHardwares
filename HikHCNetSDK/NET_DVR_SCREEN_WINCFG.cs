using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREEN_WINCFG
    {
        public uint dwSize;
        public byte byVaild;
        public byte byInputType;        //见CAM_MDOE
        public ushort wInputIdx;            /*输入源索引*/
        public uint dwLayerIdx;         /*图层，0为最底层*/
        public NET_DVR_RECTCFG struWin; //目的窗口(相对显示墙)
        public byte byWndIndex;         //窗口号
        public byte byCBD;              //0-无，1-带背景，2-不带背景
        public byte bySubWnd;           //0不是，1是
        public byte byRes1;
        public uint dwDeviceIndex;//设备序号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
