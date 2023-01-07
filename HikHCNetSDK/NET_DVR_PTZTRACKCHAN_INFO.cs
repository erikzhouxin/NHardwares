using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZTRACKCHAN_INFO
    {
        public uint dwEnablePtzTrackChan;   /*启用云台轨迹的通道*/
        public uint dwPtzTrackNo;       /*云台轨迹通道对应的编号, 0xfffffff表示无效*/
    }

}
