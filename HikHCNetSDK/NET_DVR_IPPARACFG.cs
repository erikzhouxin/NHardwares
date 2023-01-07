using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP接入配置结构 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPPARACFG
    {
        public uint dwSize;/* 结构大小 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_DEVICE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPDEVINFO[] struIPDevInfo;/* IP设备 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnalogChanEnable; /* 模拟通道是否启用，从低到高表示1-32通道，0表示无效 1有效 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_CHANNEL, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPCHANINFO[] struIPChanInfo;/* IP通道 */

        public void Init()
        {
            int i = 0;
            struIPDevInfo = new NET_DVR_IPDEVINFO[HikHCNetSdk.MAX_IP_DEVICE];

            for (i = 0; i < HikHCNetSdk.MAX_IP_DEVICE; i++)
            {
                struIPDevInfo[i].Init();
            }
            byAnalogChanEnable = new byte[HikHCNetSdk.MAX_ANALOG_CHANNUM];
            struIPChanInfo = new NET_DVR_IPCHANINFO[HikHCNetSdk.MAX_IP_CHANNEL];
            for (i = 0; i < HikHCNetSdk.MAX_IP_CHANNEL; i++)
            {
                struIPChanInfo[i].Init();
            }
        }
    }

}
