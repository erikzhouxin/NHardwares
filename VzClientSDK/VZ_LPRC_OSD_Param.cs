using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// OSD参数
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_OSD_Param
    {
        /// <summary>
        /// 0 off 1 on
        /// </summary>
        public byte dstampenable;
        /// <summary>
        /// 0:YYYY/MM/DD;1:MM/DD/YYYY;2:DD/MM/YYYY
        /// </summary>
        public int dateFormat;
        /// <summary>
        /// x坐标
        /// </summary>
        public int datePosX;
        /// <summary>
        /// y坐标
        /// </summary>
        public int datePosY;
        /// <summary>
        /// 0 off 1 on
        /// </summary>
        public byte tstampenable;
        /// <summary>
        ///  0:12Hrs;1:24Hrs
        /// </summary>
        public int timeFormat;
        /// <summary>
        /// x时间
        /// </summary>
        public int timePosX;
        /// <summary>
        /// y时间
        /// </summary>
        public int timePosY;
        /// <summary>
        /// 0 off 1 on
        /// </summary>
        public byte nLogoEnable;
        /// <summary>
        /// logo position X
        /// </summary>
        public int nLogoPositionX;
        /// <summary>
        /// logo position Y
        /// </summary>
        public int nLogoPositionY;
        /// <summary>
        /// 0 off 1 on
        /// </summary>
        public byte nTextEnable;
        /// <summary>
        /// text position
        /// </summary>
        public int nTextPositionX;
        /// <summary>
        /// text position
        /// </summary>
        public int nTextPositionY;
        /// <summary>
        /// user define text
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string overlaytext;
    }
}
