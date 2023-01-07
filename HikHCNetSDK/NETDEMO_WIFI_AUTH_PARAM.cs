using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct WIFI_AUTH_PARAM
    {
        [FieldOffsetAttribute(0)]
        public UNION_EAP_TTLS EAP_TTLS;//WPA-enterprise/WPA2-enterpris模式适用

        [FieldOffsetAttribute(0)]
        public UNION_EAP_PEAP EAP_PEAP; //WPA-enterprise/WPA2-enterpris模式适用

        [FieldOffsetAttribute(0)]
        public UNION_EAP_TLS EAP_TLS;
    }

}
