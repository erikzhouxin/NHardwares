using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INDEX
    {
        public uint iIndex;
        public void Init()
        {
            iIndex = 1;
        }
    }

}
