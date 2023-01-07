using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARM_DEVICE_USER
    {
        public uint dwSize; //Structure size
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;
        public NET_DVR_IPADDR struUserIP;//User IP (0 stands for no IP restriction)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAMCAddr;
        public byte byUserType;    //0- general user, 1- administrator user
        public byte byAlarmOnRight;//Arming authority
        public byte byAlarmOffRight; //Disarming authority
        public byte byBypassRight; //Bypass authority
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byOtherRight;//Other authority 
                                   // 0 -- log
                                   // 1 -- reboot/shutdown
                                   // 2 -- set parameter
                                   // 3 -- get parameter
                                   // 4 -- resume
                                   // 5 -- siren 
                                   // 6 -- PTZ
                                   // 7 -- remote upgrade
                                   // 8 -- preview
                                   // 9 -- manual record
                                   // 10 --remote playback
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byNetPreviewRight;// preview channels,eg. bit0-channel 1,0-no permission 1-permission enable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byNetRecordRight; // record channels,eg. bit0-channel 1,0-no permission 1-permission enable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byNetPlaybackRight; // playback channels,eg. bit0-channel 1,0-no permission 1-permission enable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byNetPTZRight; // PTZ channels,eg. bit0-channel 1,0-no permission 1-permission enable
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sOriginalPassword;        // Original password
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 152, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
