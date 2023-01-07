using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_PLAN_SEGMENT
    {
        public byte byEnable; //whether to enable, 1-enable, 0-disable
        public byte byDoorStatus; //door status(control ladder status),0-invaild, 1-always open(free), 2-always close(forbidden), 3-ordinary status(used by door plan)
        public byte byVerifyMode;  //verify method, 0-invaild, 1-swipe card, 2-swipe card +password(used by card verify ) 3-swipe card(used by card verify) 4-swipe card or password(used by card verify)
                                   //5-fingerprint, 6-fingerprint and passwd, 7-fingerprint or swipe card, 8-fingerprint and swipe card, 9-fingerprint and passwd and swipe card,
                                   //10-face or finger print or swipe card or password,11-face and finger print,12-face and password,13-face and swipe card,14-face,15-employee no and password,
                                   //16-finger print or password,17-employee no and finger print,18-employee no and finger print and password,
                                   //19-face and finger print and swipe card,20-face and password and finger print,21-employee no and face,22-face or face and swipe card
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_TIME_SEGMENT struTimeSegment;  //time segment parameter 

        public void Init()
        {
            byRes = new byte[5];
        }
    }


}
