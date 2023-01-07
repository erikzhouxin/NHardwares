using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAN_TEMPLATE_COND
    {
        public uint dwSize;
        public uint dwPlanTemplateNumber; //Plan template number, starting from 1, the maximum value from the entrance guard capability sets 
        public ushort wLocalControllerID; //On the controller serial number[1,64], 0 is invalid 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[106];
        }
    }


}
