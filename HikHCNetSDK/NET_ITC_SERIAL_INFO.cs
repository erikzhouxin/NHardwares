using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_SERIAL_INFO
    {
        public byte bySerialProtocol;
        public byte byIntervalType;
        public ushort wInterval;
        public byte byNormalPassProtocol;
        public byte byInverseProtocol;
        public byte bySpeedProtocol;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
