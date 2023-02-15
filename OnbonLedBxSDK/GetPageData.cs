using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetPageData
    {
        ushort allPageNub;
        uint pageLen;
        public byte[] fileAddre;
    }
}
