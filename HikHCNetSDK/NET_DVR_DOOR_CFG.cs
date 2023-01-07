using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DOOR_CFG
    {
        public uint dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DOOR_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDoorName;//door name
        public byte byMagneticType;//magnetic type, 0-always close 1-always open
        public byte byOpenButtonType;//open button type,  0-always close 1-always open
        public byte byOpenDuration;//open duration time, 1-255s(ladder control relay action time)
        public byte byDisabledOpenDuration;//disable open duration , 1-255s  
        public byte byMagneticAlarmTimeout;//magnetic alarm time out , 0-255s,0 means not to alarm
        public byte byEnableDoorLock;//whether to enable door lock, 0-disable, 1-enable
        public byte byEnableLeaderCard;//whether to enable leader card , 0-disable, 1-enable
        public byte byLeaderCardMode;//First card mode, 0 - first card function is not enabled, and 1 - the first card normally open mode, 2 - the first card authorization mode (using this field, the byEnableLeaderCard is invalid ) 
        public uint dwLeaderCardOpenDuration;//leader card open duration 1-1440min
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.STRESS_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byStressPassword;//stress ppassword
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SUPER_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] bySuperPassword; //super password
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.UNLOCK_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUnlockPassword;
        public byte byUseLocalController; //Read-only, whether the connection on the local controller, 0 - no, 1 - yes
        public byte byRes1;
        public ushort wLocalControllerID; //Read-only, on-site controller serial number, 1-64, 0 on behalf of unregistered 
        public ushort wLocalControllerDoorNumber; //Read-only, on-site controller door number, 1-4, 0 represents the unregistered 
        public ushort wLocalControllerStatus; //Read-only, on-site controller online status: 0 - offline, 1 - online, 2 - loop of RS485 serial port 1 on 1, 3 - loop of RS485 serial port 2 on 2, 4 - loop of RS485 serial port 1, 5 - loop of RS485 serial port 2, 6 - loop 3 of RS485 serial port 1, 7 - the loop on the RS485 serial port on the 3 4 2, 8 - loop on the RS485 serial port 1, 9 - loop 4 of RS485 serial port 2 (read-only) 
        public byte byLockInputCheck; //Whether to enable the door input detection (1 public byte, 0 is not enabled, 1 is enabled, is not enabled by default) 
        public byte byLockInputType; //Door lock input type 
        public byte byDoorTerminalMode; //Gate terminal working mode 
        public byte byOpenButton; //Whether to enable the open button 
        public byte byLadderControlDelayTime; //ladder control delay time,1-255min
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 43, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;

        public void Init()
        {
            byDoorName = new byte[HikHCNetSdk.DOOR_NAME_LEN];
            byStressPassword = new byte[HikHCNetSdk.STRESS_PASSWORD_LEN];
            bySuperPassword = new byte[HikHCNetSdk.SUPER_PASSWORD_LEN];
            byUnlockPassword = new byte[HikHCNetSdk.UNLOCK_PASSWORD_LEN];
            byRes2 = new byte[43];
        }
    }

}
