using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_REPORT_CENTER_CFG_V40
    {
        public uint dwSize;
        public byte byValid;
        public byte byDataType;            //1-All alarm data 2-not alarm data 3-all data,4-zone report,5-not zone report
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public byte[] byChanAlarmMode;//alarm channels, 1-T1,2-T2, 3-N1, 4-N2,5-G1, 6-G2 ,7-N3, 8-N4
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.Struct)]
        public byte[] byDealFailCenter; //send to these centers while send fail 0-not choose,1-choose
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.Struct)]
        public byte[] byZoneReport;    //zone report type,0-not upload,1-upload 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.Struct)]
        public byte[] byNonZoneReport; //not zone report, 0-not upload,1-upload byNonZoneReport[0]-soft zone report byNonZoneReport[1]-system status report byNonZoneReport[2]-cancel report byNonZoneReport[3]-test report byNonZoneReport[4]-arm report byNonZoneReport[5]-disarm report byNonZoneReport[6]-duress report byNonZoneReport[7]-alarm recovery report byNonZoneReport[8]-bypass report byNonZoneReport[9]-bypass restore report,byNonZoneReport[10]-detector connect status report(online/offline),byNonZoneReport[11]-detector power status report(normal/low);bit12-video alarm report
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public byte[] byAlarmNetCard;    //network card center,0-primary card_1,1-primary card_2,2-extend card_1,3-extend card_2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 252, ArraySubType = UnmanagedType.Struct)]
        public byte[] byRes2;
        public void Init()
        {
            byRes = new byte[2];
            byChanAlarmMode = new byte[4];
            byDealFailCenter = new byte[16];
            byZoneReport = new byte[512];
            byNonZoneReport = new byte[32];
            byAlarmNetCard = new byte[4];
            byRes2 = new byte[252];
        }
    }

}
