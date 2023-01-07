using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PTZ_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PTZ_PROTOCOL[] struPtz;/*最大200中PTZ协议*/
        public uint dwPtzNum;/*有效的ptz协议数目，从0开始(即计算时加1)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
