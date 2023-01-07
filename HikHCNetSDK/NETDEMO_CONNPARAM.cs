using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CONNPARAM
    {
        public uint uiUser;
        public ErrorCallback errorCB;
    }
}
