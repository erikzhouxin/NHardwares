using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SEARCH_EVENT_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLen;
        /* [FieldOffsetAttribute(0)]
         public EVENT_ALARM_BYBIT struAlarmParam;
         [FieldOffsetAttribute(0)]
         public EVENT_ALARM_BYVALUE struAlarmParamByValue;
         [FieldOffsetAttribute(0)]
         public EVENT_MOTION_BYBIT struMotionParam;
         [FieldOffsetAttribute(0)]
         public EVENT_MOTION_BYVALUE struMotionParamByValue;
         [FieldOffsetAttribute(0)]
         public EVENT_VCA_BYBIT struVcaParam;
         [FieldOffsetAttribute(0)]
         public EVENT_VCA_BYVALUE struVcaParamByValue;
         [FieldOffsetAttribute(0)]
         public EVENT_INQUEST_PARAM struInquestParam;
         [FieldOffsetAttribute(0)]
         public EVENT_VCADETECT_BYBIT struVCADetectByBit;
         [FieldOffsetAttribute(0)]
         public EVENT_VCADETECT_BYVALUE struVCADetectByValue;
         [FieldOffsetAttribute(0)]
         public EVENT_STREAMID_PARAM struStreamIDParam;
         * */
    }


}
