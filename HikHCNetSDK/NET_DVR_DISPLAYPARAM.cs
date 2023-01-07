using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示输出参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPLAYPARAM
    {
        public uint dwDisplayNo;//显示输出号
        public byte byDispChanType;/*输出连接模式,1-BNC，2-VGA，3-HDMI，4-DVI，5-SDI, 6-FIBER, \
                                    7-RGB, 8-YPrPb, 9-VGA/HDMI/DVI自适应，10-3GSDI,11-VGA/DVI自适应，12-HDBaseT, 0xff-无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
