using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CRUISE_RET
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CRUISE_POINT[] struCruisePoint;//最大支持32个巡航点

        public void Init()
        {
            struCruisePoint = new NET_DVR_CRUISE_POINT[32];
            for (int i = 0; i < 32; i++)
            {
                struCruisePoint[i].Init();
            }
        }
    }
}
