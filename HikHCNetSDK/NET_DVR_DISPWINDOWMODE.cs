using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示通道画面分割模式
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPWINDOWMODE
    {
        public byte byDispChanType;//显示通道类型：0-VGA, 1-BNC, 2-HDMI, 3-DVI
        public byte byDispChanSeq;//显示通道序号,从1开始，如果类型是VGA，则表示第几个VGA
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byDispMode;
    }
}
