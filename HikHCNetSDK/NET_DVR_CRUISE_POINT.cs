using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //巡航点配置(HIK IP快球专用)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CRUISE_POINT
    {
        public byte PresetNum;//预置点
        public byte Dwell;//停留时间
        public byte Speed;//速度
        public byte Reserve;//保留

        public void Init()
        {
            PresetNum = 0;
            Dwell = 0;
            Speed = 0;
            Reserve = 0;
        }
    }
}
