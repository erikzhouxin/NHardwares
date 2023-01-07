using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DATE
    {
        public ushort wYear;        //年
        public byte byMonth;        //月    
        public byte byDay;        //日                        
    }
}
